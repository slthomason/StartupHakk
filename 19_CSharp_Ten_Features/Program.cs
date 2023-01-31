string cleattext = File.ReadAllText(@"C:\countries.txt");
Dictionary<string,string> dic = new Dictionary<string, string>();
CultureInfo info = new CultureInfo("en-GB");
XmlWriter writer = null;



