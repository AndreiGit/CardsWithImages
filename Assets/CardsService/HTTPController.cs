using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

namespace CardsService
{
    public class HTTPController : IHTTPController
    {
        private string _url = "https://picsum.photos/200/300";

        public async UniTask<Texture2D> GetTextureAsync(CancellationToken cancellationToken)
        {
            using var www = UnityWebRequestTexture.GetTexture(_url);

            await www.SendWebRequest().WithCancellation(cancellationToken);

            return www.result == UnityWebRequest.Result.Success ? DownloadHandlerTexture.GetContent(www) : null;
        }
    }
}
