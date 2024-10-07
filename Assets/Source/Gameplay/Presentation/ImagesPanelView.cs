using UnityEngine;
using UnityEngine.UIElements;

namespace Source.Gameplay.Presentation
{
    public class ImagesPanelView : MonoBehaviour
    {
        [SerializeField] private UIDocument _imagesPanel;
        private ListView _listView;

        public bool Visible { set => _listView.visible = value; }

        private void Start() 
            => _listView = _imagesPanel.rootVisualElement.Q<ListView>();
    }
}