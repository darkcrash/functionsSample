using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri} ");


    string content = await req.Content.ReadAsStringAsync();
    string[] lines = content.Split('\n');
    var data = new Dictionary<string, string>();
    foreach(var line in lines)
    {
        var keyVal = line.Split(new char[] {'='}, 2);
        data[keyVal[0]] = keyVal[1];
    }
    
    // Get request body
    //dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    //string gitHubComment = data?.comment?.body;
    log.Info($"user_name:{data["user_name"]}");

    return req.CreateResponse(HttpStatusCode.OK, "From Slack:" + data["user_name"]);
}