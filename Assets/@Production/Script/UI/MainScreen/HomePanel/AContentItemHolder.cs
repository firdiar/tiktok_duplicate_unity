using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    /// <summary>
    /// Item holder, special for ContentItemView
    /// </summary>
    public abstract class AContentItemHolder : AMenuView
    {
        public abstract List<Graphic> GetAllGraphic();

        public void SetAlpha(float alpha, float duration = 0.2f)
        { 
            var graphic = GetAllGraphic();
            foreach (Graphic g in graphic) 
            {
                g.DOFade(alpha, duration);
            }
        }
    }
}