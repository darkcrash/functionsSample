using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");

    string content = await req.Content.ReadAsStringAsync();
    var data = new Dictionary<string, string>();
    foreach (var line in content.Split('&'))
    {
        log.Info($"line={line}");
        var keyVal = line.Split(new char[] { '=' }, 2);
        data[keyVal[0]] = keyVal[1];
    }

    string userName = "empty";
    if (data.ContainsKey("user_name")) userName = data["user_name"];


    if (userName == "slackbot") return req.CreateResponse(HttpStatusCode.OK);

    log.Info($"user_name:{userName}");
    return req.CreateResponse(HttpStatusCode.OK, new
    {
        text = $"Hello {userName}!"
    });
}