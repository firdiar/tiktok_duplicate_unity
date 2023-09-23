using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class ProfileHolder : AContentItemHolder
    {
        [SerializeField]
        Image userProfileImage;
        [SerializeField]
        Button button;

        [SerializeField]
        List<Graphic> allGraphic;

        Action onClick;

        private void Start()
        {
            button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void Initialize(Sprite sprite, Action onClick)
        {
            userProfileImage.sprite = sprite;
            this.onClick = onClick;
        }

        public override List<Graphic> GetAllGraphic()
        {
            return allGraphic;
        }
    }
}