using Gtion.Plugin.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    [RequireComponent(typeof(Graphic))]
    public class ThemeComponent : MonoBehaviour
    {
        [SerializeField]
        ThemeKind kind;
        [SerializeField]
        Graphic graphics;

        [GInject]
        ThemeManager themeManager;

        private void OnValidate()
        {
            if(graphics == null) 
            {
                graphics = GetComponent<Graphic>();
            }
        }

        private void Start()
        {
            GDi.Request(this, OnReady);
        }

        private void OnReady() 
        {
            themeManager.OnThemeChanged += InitTheme;
            InitTheme();
        }

        private void OnDestroy()
        {
            if (themeManager != null)
            {
                themeManager.OnThemeChanged -= InitTheme;
            }
        }

        private void InitTheme() 
        {
            graphics.color = themeManager.ActiveTheme.GetColor(kind);
        }
    }
}
