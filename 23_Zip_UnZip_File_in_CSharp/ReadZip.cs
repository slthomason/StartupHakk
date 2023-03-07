using (var target = File.OpenRead("Simple.zip")) 
{
  using var newArchive = new ZipArchive(target, ZipArchiveMode.Read);

  var entry = newArchive.GetEntry("Simple.txt");

  if (entry != null) 
  { 
    using var entryStream = entry.Open(); 
    using var reader = new StreamReader(entryStream);
    var line = reader.ReadLine(); 
  }
}

 
using (var file = ZipFile.OpenRead("Simple.zip")) { }

using (var file = ZipFile.Open("Simple.zip", ZipArchiveMode.Create)) { }

ZipFile.CreateFromDirectory(".", "Content.zip");
ZipFile.ExtractToDirectory("Content.zip", "Secret Content");
  