using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class DescriptionBar : AContentItemHolder
    {
        const string Ellipsis = " ...";
        bool isExpand = false;

        [Header("Basic")]
        [SerializeField]
        RectTransform barHolder;
        [SerializeField]
        TextMeshProUGUI username;
        [SerializeField]
        TextMeshProUGUI song;
        [SerializeField]
        Button expandButton;
        [SerializeField]
        TextMeshProUGUI expandText;

        [Header("ShortDesc")]   
        [SerializeField]
        GameObject shortDescHolder;
        [SerializeField]
        TextMeshProUGUI shortDesc;
        [SerializeField]
        int maxLength = 40;
        [SerializeField]
        int shortHeight = 305;

        [Header("FullDesc")]
        [SerializeField]
        GameObject fullDescHolder;
        [SerializeField]
        TextMeshProUGUI fullDesc;
        [SerializeField]
        RectTransform fullDescRect;
        [SerializeField]
        int fullHeight = 900;

        [Header("Extra")]
        [SerializeField]
        List<Graphic> additionalGraphic = new List<Graphic>();

        public override List<Graphic> GetAllGraphic()
        {
            List<Graphic> result = additionalGraphic.ToList();
            result.Add(username);
            result.Add(song);
            result.Add(expandText);
            result.Add(shortDesc);
            result.Add(fullDesc);
            return result;
        }

        private void Start()
        {
            expandButton.onClick.AddListener(ToggleExpand);
        }

        public void Initialize(ContentData content)
        {
            username.text = $"@{content.username}";
            song.text = $"@{content.songName}";

            bool isShorted = TruncateString(content.description, out var shortVersion);
            shortDesc.text = shortVersion;
            fullDesc.text = content.description;
            expandButton.gameObject.SetActive(isShorted);

            SetDesc(false, false);
        }

        private bool TruncateString(string input, out string shortString)
        {
            // If there are more than 2 lines, take the first two lines and append ellipsis to the second line
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > 2)
            {
                shortString = lines[0] + "\n" + lines[1] + Ellipsis;
                return true;
            }

            // If string is longer than MaxLength, truncate and append ellipsis
            if (input.Length > maxLength)
            {
                shortString = input.Substring(0, maxLength) + Ellipsis;
                return true;
            }

            // Otherwise, return the input string as it is
            shortString = input;
            return false;
        }

        private void ToggleExpand() 
        {
            SetDesc(!isExpand, true);
        }

        private async void SetDesc(bool isExpanded, bool isAnimated)
        {
            if (isExpand == isExpanded) return; //nothing to change

            shortDescHolder.SetActive(!isExpanded);
            fullDescHolder.SetActive(isExpanded);
            isExpand = isExpanded;
            expandText.text = isExpand ? "See Less..." : "See More...";
            await Task.Delay(10);

            float fullHeightAdjusted = Mathf.Min(fullDescRect.sizeDelta.y + 250, fullHeight);
            var targetSizeDelta = new Vector2(0, isExpand ? fullHeightAdjusted : shortHeight);
            if (isAnimated)
            {
                barHolder.DOSizeDelta(targetSizeDelta, 0.2f);
            }
            else
            {
                barHolder.sizeDelta = targetSizeDelta;
            }
            
        }
    }
}
