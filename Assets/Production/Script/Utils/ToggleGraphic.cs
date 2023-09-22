using Gtion.Plugin.DI;
using Gtion.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.Utils.UI
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleGraphic : MonoBehaviour
    {
        [SerializeField]
        Toggle toggle;

        [SerializeField]
        ThemeKind activeTheme;
        [SerializeField]
        ThemeKind innactiveTheme;

        Color activeColor = Color.white;
        Color innactiveColor = Color.gray;

        [SerializeField]
        List<Graphic> graphics = new List<Graphic>();

        [GInject]
        ThemeManager themeManager;

        private void Start()
        {
            toggle.onValueChanged.AddListener(OnActive);
            GDi.Request(this, OnReady);
        }

        private void OnReady()
        {
            themeManager.OnThemeChanged += InitColor;
            InitColor();
        }

        private void InitColor() 
        {
            activeColor = themeManager.ActiveTheme.GetColor(activeTheme);
            innactiveColor = themeManager.ActiveTheme.GetColor(innactiveTheme);
            OnActive(toggle.isOn);
        }

        private void OnActive(bool isActive) 
        {
            foreach (Graphic g in graphics) 
            {
                g.color = isActive ? activeColor : innactiveColor;
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (toggle == null)
            {
                toggle = GetComponent<Toggle>();
            }
        }
#endif
    }
}
