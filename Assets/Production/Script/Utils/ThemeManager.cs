using Gtion.Plugin.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gtion.UI
{
    public enum ThemeMode
    {
        Light,
        Dark
    }
    public enum ThemeKind
    { 
        Text,
        Background,
        Icon,
        Disabled,
    }

    [System.Serializable]
    public class ThemeData
    {
        [System.Serializable]
        public struct PairKind
        {
            public ThemeKind Kind;
            public Color Color;
        }
        public ThemeMode ThemeMode;
        public List<PairKind> Kinds;

        public Color GetColor(ThemeKind kind) 
        {
            return Kinds.Find(item => item.Kind == kind).Color;
        }
    }

    public class ThemeManager : MonoBehaviour
    {
        [SerializeField]
        ThemeMode currentTheme = ThemeMode.Dark;

        [SerializeField]
        List<ThemeData> themes = new List<ThemeData>();

        public ThemeData ActiveTheme { get; private set; }
        public event Action OnThemeChanged;

        public bool triggerChanges;
        private void OnValidate()
        {
            if (Application.isPlaying && triggerChanges)
            {
                OnThemeChanged?.Invoke();
            }
        }

        private void Start()
        {
            Init();
            GDi.Register(this);
        }

        public void ChangeTheme(ThemeMode newTheme) 
        {
            if (currentTheme == newTheme) return; //nothing to be changed

            currentTheme = newTheme;
            Init();
        }

        private void Init()
        {
            ActiveTheme = themes.Find(item => item.ThemeMode == currentTheme);
            OnThemeChanged?.Invoke();
        }
    }
}