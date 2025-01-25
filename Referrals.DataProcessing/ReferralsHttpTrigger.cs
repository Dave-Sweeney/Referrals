using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Referrals.DataProcessing;

public class ReferralsHttpTrigger
{
  [Function(nameof(ReferralsHttpTrigger))]
  public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
    FunctionContext executionContext)
  {
    var logger = executionContext.GetLogger(nameof(ReferralsHttpTrigger));

    var response = req.CreateResponse(HttpStatusCode.OK);

    return response;
  }
}
