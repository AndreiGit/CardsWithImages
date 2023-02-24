using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace CardsService
{
    public interface IHTTPController
    {
        UniTask<Texture2D> GetTextureAsync(CancellationToken cancellationToken);
    }
}
