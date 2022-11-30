using System.Xml.Serialization;
namespace _10_Mininum_WebApi_Xml_Output
{

    public class Approach1<T> : IResult
    {
        // Create the serializer that will actually perform the XML serialization
        private static readonly XmlSerializer Serializer = new(typeof(T));

        // The object to serialize
        private readonly T _result;

        public Approach1(T result)
        {
            _result = result;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            // NOTE: best practice would be to pull this, we'll look at this shortly
            using var ms = new MemoryStream();

            // Serialize the object synchronously then rewind the stream
            Serializer.Serialize(ms, _result);
            ms.Position = 0;

            httpContext.Response.ContentType = "application/xml";
            await ms.CopyToAsync(httpContext.Response.Body);
        }
    }
}
