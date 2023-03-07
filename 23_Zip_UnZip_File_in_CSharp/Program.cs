using System.IO.Compression; 

using (var target = File.Create("Simple.zip")) 
{
   using var archive = new ZipArchive(target, ZipArchiveMode.Create);
} 

var entry = archive.CreateEntry( "Simple.txt", CompressionLevel.Optimal);    