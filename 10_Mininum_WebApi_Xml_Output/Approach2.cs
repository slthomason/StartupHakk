using System.Xml.Serialization;
using Microsoft.AspNetCore.WebUtilities;

namespace _10_Mininum_WebApi_Xml_Output
{

    public class Approach2<T> : IResult
    {
        private static readonly XmlSerializer Serializer = new(typeof(T));
        private readonly T _result;

        public Approach2(T result)
        {
            _result = result;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            // 👇Create a FileBufferingWriteStream instead of a MemoryStream here
            using var ms = new FileBufferingWriteStream();
            Serializer.Serialize(ms, _result);

            httpContext.Response.ContentType = "application/xml";
            await ms.DrainBufferAsync(httpContext.Response.Body);
            // 👆 Call DrainBufferAsync instead of CopyToAsync, and don't call ms.Position = 0
        }
    }
}