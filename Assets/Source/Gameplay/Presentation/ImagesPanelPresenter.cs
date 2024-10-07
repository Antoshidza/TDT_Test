using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Source.App.ImageLoader;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Source.Gameplay.Presentation
{
    public class ImagesPanelPresenter
    {
        public ImagesPanelPresenter(UIDocument imagesPanel, int imagesCount, ImageLoadService imageLoadService, CancellationToken ct)
        {
            var imagesData = new List<ImageData>(imagesCount);
            
            var listView = imagesPanel.rootVisualElement.Q<ListView>();
            listView.itemsSource = imagesData;
            listView.bindItem += (root, imageIndex) =>
            {
                var imageData = imagesData[imageIndex];
                
                var imageUi = root.Q("image");
                imageUi.style.backgroundImage = new StyleBackground(imageData.Texture);

                var labelUi = root.Q<Label>();
                labelUi.text = string.Format(labelUi.text, imageData.Price.ToString("N0").Replace(',', ' '));
            };
            
            for (int i = 0; i < imagesCount; i++) 
                imageLoadService.LoadImage(ct).ContinueWith(tex =>
                {
                    imagesData.Add(new ImageData 
                    { 
                        Texture = tex, 
                        Price = Random.Range(0, int.MaxValue) 
                    });
                    listView.RefreshItems();
                }).Forget();
        }

        private struct ImageData
        {
            public Texture2D Texture;
            public int Price;
        }
    }
}