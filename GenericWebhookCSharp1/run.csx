#r "Newtonsoft.Json"

using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();
//    jsonContent = jsonContent.Replace("=", """ : """);
//    jsonContent = $"{{{jsonContent}}}";
    string[] lines = jsonContent.Split('\n');
    var data = new Dictionary<string, string>();
    foreach(var line in lines)
    {
        var keyVal = line.Split(new char[] {'='}, 2);
        data[keyVal[0]] = keyVal[1];
    }

//    dynamic data = JsonConvert.DeserializeObject(jsonContent);

//    if (data.first == null || data.last == null) {
//    if (data["first"] == null || data["last"] == null) {
//        return req.CreateResponse(HttpStatusCode.BadRequest, new {
//            error = "Please pass first/last properties in the input object"
//        });
//    }

    log.Info($"user_name:{data["user_name"]}");
    return req.CreateResponse(HttpStatusCode.OK, new {
        text = $"Hello {data["user_name"]}!"
    });
}
