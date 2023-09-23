using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gtion.UI
{
    public abstract class AMenuView : MonoBehaviour
    {
        public virtual void Show() 
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}