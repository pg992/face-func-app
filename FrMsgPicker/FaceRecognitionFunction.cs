using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;

namespace FrMsgPicker
{
    public static class FaceRecognitionFunction
    {
        [FunctionName("Function1")]
        public static async Task Run([QueueTrigger("face-recognition", Connection = "fsStorage")]string myQueueItem, [SignalR(HubName = "chat")]IAsyncCollector<SignalRMessage> signalRMessages)
        {
            await signalRMessages.AddAsync(new SignalRMessage
            {
                Target = "notify",
                Arguments = new [] {myQueueItem}
            });
        }
    }
}