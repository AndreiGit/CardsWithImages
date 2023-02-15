using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CardsService
{
    public interface IHTTPController
    {
        UniTask<Texture2D> GetTextureAsync();
    }
}
