using (var target = File.Create("Simple.zip"))
{
  using var newArchive = new ZipArchive(target, ZipArchiveMode.Create);
  newArchive.CreateEntryFromFile("Simple.txt", "Simple.txt"); 
}
  