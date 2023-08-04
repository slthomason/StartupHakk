using System;
using System.IO;
using ICSharpCode.SharpZiplib.Core; 
using ICSharpCode.SharpZiplib.GZip;

// <summary>
// Extracts the file contained within a GZip to the target dir.
// A GZip can contain only one file, which by default is named the same as the GZip except 
// without the extension.
// </summary>
public void ExtractGZipSample(string gzipFileName , string targetOir) 
{
// Use a 4K buffer. Any larger is a waste. 
    byte [] dataBuffer = new byte [4096];
    using (System.IO.Stream fs = new FileStream (gzipFileName, 
    FileMode.Open, FileAccess.Read)) 
    {
        using (GZipinputStream gzipStream = new GZipinputStream (fs))
        {
            // Change this to your needs
            string fnOut = Path.Combine(targetOir, 
            Path.GetFileNameWithoutExtension(gzipFileName));
            using (FileStream fsOut = File.Create(fnOut))
            {
                StreamUtils.Copy (gzipStream, fsOut, dataBuffer);
            }
        }
    }
}
