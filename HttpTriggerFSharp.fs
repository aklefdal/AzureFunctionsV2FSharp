namespace Company.Function

open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging

module HttpTriggerFSharp =
    [<FunctionName("HttpTriggerFSharp")>]
    let run ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>] req:HttpRequest, log:ILogger) =
        log.LogInformation("C# HTTP trigger function processed a request.")

        let name = req.Query.["name"].[0]

        if name <> null then
            sprintf "Hello, %s" name |> OkObjectResult :> ActionResult
        else 
            "Please pass a name on the query string or in the request body" |> BadRequestObjectResult :> ActionResult
