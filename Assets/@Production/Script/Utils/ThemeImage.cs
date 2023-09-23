using Gtion.Plugin.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    [RequireComponent(typeof(Image))]
    public class ThemeImage : MonoBehaviour
    {
        [Serializable]
        public class PairImage
        {
            [SerializeField]
            ThemeMode mode;
            [SerializeField]
            Sprite sprite;

            public ThemeMode Mode => mode;
            public Sprite Sprite => sprite;
        }

        [SerializeField]
        List<PairImage> pairs = new List<PairImage>();
        [SerializeField]
        Image graphics;

        [GInject]
        ThemeManager themeManager;

        private void OnValidate()
        {
            if (graphics == null)
            {
                graphics = GetComponent<Image>();
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
            var pair = pairs.Find(item => item.Mode == themeManager.ActiveTheme.ThemeMode);
            if (pair != null)
            {
                graphics.sprite = pair.Sprite;
            }
            else
            {
                Debug.LogError($"Config for Theme `{themeManager.ActiveTheme.ThemeMode}` not exist!");
            }
        }
    }
}
