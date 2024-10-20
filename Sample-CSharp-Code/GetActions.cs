using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GhostHttp.Extensions;

namespace GhostHttp.Host
{
    public class GetActions
    {
        public async Task Ping(HttpProcessor processor)
        {
            var req = await processor.GetJsonBody<PingRequest>();

            await processor.WriteJson(new PongResponse
            {
                Response = req?.Request ?? await processor.GetRequestBody()
            });
        }

        public async Task File(HttpProcessor processor)
        {
            var form = await processor.GetForm();

            var files = await processor.GetFiles();
            foreach (var webFile in files)
            {
                var fileName = Path.GetFileName(webFile.Path);
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    System.IO.File.WriteAllBytes(fileName, webFile.Content);
                }
            }

            await processor.WriteRaw(string.Join("<br />", form.Select(x => $"{x.Key}: {x.Value}")));
        }
    }

    public class PingRequest
    {
        public string Request { get; set; }
    }

    public class PongResponse
    {
        public string Response { get; set; }
    }
}