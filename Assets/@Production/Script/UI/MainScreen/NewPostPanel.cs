using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class NewPostPanel : APanel
    {
        [SerializeField]
        Button closeButton;
        public override PanelType Type => PanelType.NewPost;

        private void Start()
        {
            closeButton.onClick.AddListener(() => Hide());
        }
    }
}
