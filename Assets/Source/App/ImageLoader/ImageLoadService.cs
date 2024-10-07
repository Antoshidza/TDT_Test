using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Source.App.ImageLoader
{
    public class ImageLoadService
    {
        public async UniTask<Texture2D> LoadImage(CancellationToken ct) =>
            DownloadHandlerTexture.GetContent(await UnityWebRequestTexture
                .GetTexture($"https://random.imagecdn.app/{Random.Range(500, 1000)}/{Random.Range(500, 1000)}")
                .SendWebRequest()
                .WithCancellation(ct));
    }
}