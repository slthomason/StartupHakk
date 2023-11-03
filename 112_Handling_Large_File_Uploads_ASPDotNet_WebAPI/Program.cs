[Route("api/upload/chunk")]
[HttpPost]
public IHttpActionResult UploadChunk(FileChunk chunk)
{
    try
    {
        var chunkNumber = chunk.ChunkNumber;
        var totalChunks = chunk.TotalChunks;
        var fileId = chunk.FileId;

        var uploadPath = Path.Combine(Server.MapPath("~/uploads"), fileId);
        var chunkFilePath = Path.Combine(uploadPath, $"{chunkNumber}.part");

        HttpContext.Current.Request.Files[0].SaveAs(chunkFilePath);

        if (chunkNumber == totalChunks)
        {
            // Combine all chunks to create the final file
            CombineChunks(uploadPath, fileId, totalChunks);
            DeleteChunks(uploadPath, totalChunks);
        }

        return Ok("Chunk uploaded successfully.");
    }
    catch (Exception ex)
    {
        // Log the error and provide an informative response
        Log.Error(ex, "Error uploading chunk.");
        return InternalServerError();
    }
}

//FileChunk class 
public class FileChunk
{
    public int ChunkNumber { get; set; }
    public int TotalChunks { get; set; }
    public string FileId { get; set; }
}







//CombineChunks 
private void CombineChunks(string uploadPath, string fileId, int totalChunks)
{
    var finalFilePath = Path.Combine(uploadPath, fileId);
    using (var finalStream = File.Create(finalFilePath))
    {
        for (int i = 1; i <= totalChunks; i++)
        {
            var chunkFilePath = Path.Combine(uploadPath, $"{i}.part");
            using (var chunkStream = File.OpenRead(chunkFilePath))
            {
                chunkStream.CopyTo(finalStream);
            }
        }
    }
}

private void DeleteChunks(string uploadPath, int totalChunks)
{
    for (int i = 1; i <= totalChunks; i++)
    {
        var chunkFilePath = Path.Combine(uploadPath, $"{i}.part");
        File.Delete(chunkFilePath);
    }
}


//Server-side Implementation (ASP.NET Web API):

[Route("api/upload/file")]
[HttpPost]
public IHttpActionResult UploadFile()
{
    if (!Request.Content.IsMimeMultipartContent())
    {
        return BadRequest("Unsupported media type.");
    }

    var provider = new MultipartFormDataStreamProvider(uploadPath);
    var result = Request.Content.ReadAsMultipartAsync(provider).Result;

    foreach (var file in result.FileData)
    {
        var fileName = file.Headers.ContentDisposition.FileName.Trim('"');
        var filePath = Path.Combine(uploadPath, fileName);
        File.Move(file.LocalFileName, filePath);
    }

    return Ok("File uploaded successfully.");
}

//Combine Chunks

private void CombineChunks(string uploadPath, string fileId, int totalChunks)
{
    var finalFilePath = Path.Combine(uploadPath, fileId);
    using (var finalStream = File.Create(finalFilePath))
    {
        for (int i = 1; i <= totalChunks; i++)
        {
            var chunkFilePath = Path.Combine(uploadPath, $"{i}.part");
            using (var chunkStream = File.OpenRead(chunkFilePath))
            {
                chunkStream.CopyTo(finalStream);
            }
            File.Delete(chunkFilePath); // Clean up individual chunks
        }
    }
}