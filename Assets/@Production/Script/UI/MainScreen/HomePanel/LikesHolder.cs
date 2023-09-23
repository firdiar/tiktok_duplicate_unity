using BrunoMikoski.AnimationSequencer;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class LikesHolder : TextCountHolder
    {
        [SerializeField]
        Image likeIcon;

        Transform likeIconTransform => likeIcon.transform;

        private bool isLiked;
        public bool IsLiked => isLiked;

        public void Initialize(long amount, bool isLiked, Action<bool> onClick)
        {
            this.isLiked = isLiked;
            
            //Init Like Graphic
            likeIconTransform.localScale = isLiked ? Vector3.one : Vector3.zero;

            var col = likeIcon.color;
            col.a = isLiked ? 1 : 0;
            likeIcon.color = col;

            Initialize(amount, () =>
            {
                LikeChange();
                onClick?.Invoke(this.isLiked);
            });
        }

        public void LikeChange()
        {
            isLiked = !isLiked;
            if (isLiked)
            {
                likeIconTransform.DOScale(1, 0.35f).SetEase(Ease.OutBack);
                likeIcon.DOFade(1, 0.2f);
            }
            else
            {
                likeIconTransform.DOScale(0, 0.25f);
                likeIcon.DOFade(0, 0.2f);
            }
        }

        public override List<Graphic> GetAllGraphic()
        {
            return new List<Graphic>(3)
            {
                likeIcon,
                button.targetGraphic,
                textCount
            };
        }
    }
}
