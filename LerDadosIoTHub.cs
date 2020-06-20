using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace TrabalhoIoTFuncoes
{
    public static class LerDadosIoTHub
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("LerDadosIoTHub")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "ConexaoIoTHub")]EventData message, ILogger log)
        {
            var uriPowerBI = "https://api.powerbi.com/beta/11dbbfe2-89b8-4549-be10-cec364e59551/datasets/c6286209-81dc-4c34-8824-eaa4c25fc94e/rows?key=6VmcxSCrJvtdqDNN9L8o%2BNaQujKGHngVNKpoRkp81hA9vqPqvy6%2Blm2kehVSjC66j8qXdovGOdzbfntwS%2Bpryg%3D%3D";
            client.PostAsync(uriPowerBI, new StringContent(Encoding.UTF8.GetString(message.Body.Array), Encoding.UTF8, "application/json"));
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}