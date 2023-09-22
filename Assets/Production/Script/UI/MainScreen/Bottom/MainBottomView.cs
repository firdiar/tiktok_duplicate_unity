using Gtion.Plugin.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class MainBottomView : MonoBehaviour
    {
        [System.Serializable]
        public class OptionPair
        {
            [SerializeField]
            PanelType panelType;
            [SerializeField]
            Toggle toggle;

            public PanelType PanelType => panelType;
            public Toggle Toggle => toggle;
        }

        [SerializeField]
        List<OptionPair> optionPair = new List<OptionPair>();

        [GInject]
        MainScreenView mainScreenView;
        [GInject]
        ThemeManager themeManager;

        private void Start()
        {
            foreach(var pair in optionPair) 
            {
                pair.Toggle.onValueChanged.AddListener(isOn =>
                {
                    if (isOn)
                    {
                        OnOptionSelected(pair.PanelType);
                    }
                });
            }
        }

        private void OnOptionSelected(PanelType panelType)
        {
            themeManager.ChangeTheme(panelType == PanelType.Home ? ThemeMode.Dark : ThemeMode.Light);
        }
    }
}