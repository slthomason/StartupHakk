
//Always set the Accept request header

var mt = new MediaTypeWithQualityHeaderValue("application/json");

client.DefaultRequetHeaders.Accept.Add(mt);


var request = new HttpRequestMessage(HttpMethod.Get, "api/orders");

var mt = new MediaTypeWithQualityHeaderValue("application/json");

request.Headers.Accept.Add(mt);


//Use Streams when reading responses

var response = await client.SendAsync(request);

using(var stream = await response.Content.ReadAsStreamAsync())
{
    using (var streamReader = new StreamReader(stream))
    {
      using (var jsonTextReader = new JsonTextReader(streamReader))
      {
        var customer = new JsonSerializer().Deserialize<Customer>(jsonTextReader);      
	  
        // do something with the customer
      }
    }
}

//Start reading response content ASAP

var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

//Define custom Content types

public class JsonContent : StringContent
{
    public JsonContent(string content)
        : this(content, Encoding.UTF8)
    {
    }

    public JsonContent(string content, Encoding encoding)
        : base(content, encoding, "application/json")
    {
    }
}

public class XmlContent : StringContent
{
    public XmlContent(string content) 
        : this(content, Encoding.UTF8)
    {
    }

    public XmlContent(string content, Encoding encoding)
        : base(content, encoding, "application/xml")
    {
    }
}

var request = new HttpRequestMessage(HttpMethod.Post, "api/orders");

request.Content = new JsonContent(json);


//Check the response status code

var response = await client.SendAsync(request);

if (response.StatusCode == HttpStatusCode.Unauthorized)
{
    // need to refresh the request security token!
}

if (response.IsSuccessStatusCode)
{
    // the status code was 2xx
}

//Check the response content on errors

var response = await client.SendAsync(request);

if (response.StatusCode == HttpStatusCode.BadRequest)
{
    var details = await response.Content.ReadAsStringAsync();
}

//Check the response Content-Type

var response = await client.SendAsync(request);

if (response.Content.Headers.ContentType.MediaType == "application/json")
{
    var json = await response.Content.ReadAsStringAsync();
  
    var order = JsonConvert.DeserializeObject<Order>(json);
}

//Use Cancellation Tokens

public async Task<Order> GetOrderAsync(CancellationToken cancellationToken = default)
{
    // setup your client & request
  
    var response = await client.SendAsync(request, cancellationToken);
}

//Use Compression when dealing with large responses

// Tell HttpClient to auto decompress responses using the 
// particular compression method (e.g. GZip).
var client = new HttpClient(new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip
});

// ...

// Tell the API we only want responses in gzip format.
request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
