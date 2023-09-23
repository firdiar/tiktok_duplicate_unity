using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class SongHolder : AContentItemHolder
    {
        [SerializeField]
        Image fadeImage;
        [SerializeField]
        Image rotateImage;
        [SerializeField]
        Button button;

        Action onClick;

        public override List<Graphic> GetAllGraphic()
        {
            return new List<Graphic>(2)
            {
                fadeImage,
                rotateImage
            };
        }

        private void Start()
        {
            button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void Initialize(Sprite image, Action onClick)
        { 
            fadeImage.sprite = image;
            rotateImage.sprite = image;
            this.onClick = onClick;
        }
    }
}