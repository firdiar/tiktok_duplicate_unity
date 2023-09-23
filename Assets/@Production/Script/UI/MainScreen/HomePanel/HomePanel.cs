using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gtion.UI
{
    public class HomePanel : APanel
    {
        public override PanelType Type => PanelType.Home;

        [SerializeField]
        Toggle formeToggle;
        [SerializeField]
        bool isForme;

        //This logic duplication is intentional due to time limitation :"
        [Header("Following")]
        [SerializeField]
        GameObject followingScrollHolder;
        [SerializeField]
        List<ContentItemView> followingItem;
        [SerializeField]
        SimpleScrollSnap followingScrollSnap;

        ContentItemView followingFocusItem;

        [Header("Forme")]
        [SerializeField]
        GameObject formeScrollHolder;
        [SerializeField]
        List<ContentItemView> forMeItem;
        [SerializeField]
        SimpleScrollSnap formeScrollSnap;


        ContentItemView formeFocusItem;

        private void Start()
        {
            formeToggle.onValueChanged.AddListener(OnFormeChange);

            formeScrollSnap.OnBeginDragg.AddListener(OnBeginDrag);
            formeScrollSnap.OnPanelSelected.AddListener(OnSelected);
            followingScrollSnap.OnBeginDragg.AddListener(OnBeginDrag);
            followingScrollSnap.OnPanelSelected.AddListener(OnSelected);

            OnFormeChange(formeToggle.isOn);
            OnSelected(0);
        }

        private void OnFormeChange(bool isForme)
        {
            this.isForme = isForme;
            followingScrollHolder.SetActive(!isForme);
            formeScrollHolder.SetActive(isForme);
        }

        private void OnBeginDrag() 
        {
            (isForme ? formeFocusItem : followingFocusItem)?.SetAlpha(0.5f);
        }

        private void OnSelected(int index)
        {
            List<ContentItemView> list = isForme ? forMeItem : followingItem;
            list[index].SetAlpha(1.0f);

            if (isForme)
            {
                formeFocusItem = list[index];
            }
            else
            { 
                followingFocusItem = list[index];
            }
        }
    }
}