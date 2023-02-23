//BeforeAbstraction
public interface IJsonFileParser
{ 
    bool Exists(string filePath);
    Stream GetFileStream(string filePath);
    T Parse<T>(Stream stream);
    Dispose(Stream stream);
}

//Abstraction
public interface IJsonFileParser
{
    T Parse<T>(string filePath); 
}
 