using System.IO.Compression; 

using (var target = File.Create("Simple.zip"))
{ 
  using var newArchive = new ZipArchive(target, ZipArchiveMode.Create);
  var entry = newArchive.CreateEntry( "Simple.txt", CompressionLevel.Optimal);

  using var stream  = entry.Open();
  using var writer = new StreamWriter(stream);

  writer.WriteLine("World of Zip"); 
}    