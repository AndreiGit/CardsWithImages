using Cysharp.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;

namespace CardsService
{
    public class HTTPController
    {
        private string _url = "https://picsum.photos/200/300";

        public async UniTask<Texture2D> GetTextureAsync()
        {
            using var www = UnityWebRequestTexture.GetTexture(_url);

            await www.SendWebRequest();

            return www.result == UnityWebRequest.Result.Success ? DownloadHandlerTexture.GetContent(www) : null;
        }
    }
}
