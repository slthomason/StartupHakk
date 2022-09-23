using System.Xml.Serialization;
using Microsoft.AspNetCore.WebUtilities;

namespace _10_Mininum_WebApi_Xml_Output
{
    public static class StreamManager
    {
        // 👇 Create a shared RecyclableMemoryStreamManager instance
        public static readonly Microsoft.IO.RecyclableMemoryStreamManager Instance = new();
    }
    public class Approach3<T> : IResult
    {
        private static readonly XmlSerializer Serializer = new(typeof(T));
        private readonly T _result;

        public Approach3(T result)
        {
            _result = result;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            // 👇Use in place of the MemoryStream here
            using var ms = StreamManager.Instance.GetStream();
            Serializer.Serialize(ms, _result);

            httpContext.Response.ContentType = "application/xml";
            ms.Position = 0;
            await ms.CopyToAsync(httpContext.Response.Body);
        }
    }
}
