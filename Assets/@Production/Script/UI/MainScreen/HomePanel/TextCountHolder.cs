using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class TextCountHolder : AContentItemHolder
    {
        [SerializeField]
        protected Button button;
        [SerializeField]
        protected TextMeshProUGUI textCount;

        Action onClick;

        private void Start()
        {
            button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void Initialize(long amount, Action onClick)
        { 
            this.onClick = onClick;
            textCount.text = ConvertToShortString(amount);
        }

        private string ConvertToShortString(long number)
        {
            if (number < 1000)
                return number.ToString();

            if (number < 1_000_000)
                return TrimEnd($"{number / 1000.0:0.#}K");

            if (number < 1_000_000_000)
                return TrimEnd($"{number / 1_000_000.0:0.#}M");

            return TrimEnd($"{number / 1_000_000_000.0:0.#}B");
        }

        // This helper method trims the trailing .0 from numbers (e.g., "1.0K" becomes "1K")
        private string TrimEnd(string value)
        {
            return value.EndsWith(".0") ? value.Substring(0, value.Length - 2) : value;
        }

        public override List<Graphic> GetAllGraphic()
        {
            return new List<Graphic>(2)
            {
                button.targetGraphic,
                textCount
            };
        }
    }
}