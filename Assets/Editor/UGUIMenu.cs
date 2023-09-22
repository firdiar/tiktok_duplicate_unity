using UnityEditor;
using UnityEngine;

// Created by V(Firdi) aka Firdiansyah Ramadhan
// ©2022 MIT

namespace Firdi.Plugin.UGUIAutoFitter
{
    public class UGUIMenu
    {
        [MenuItem("Tools/UI/Set Anchor Around Object")]
        protected static void uGUIAnchorAroundObject()
        {
            var o = Selection.activeGameObject;
            if (o != null && o.TryGetComponent<RectTransform>(out var r))
            {
                var p = o.transform.parent.GetComponent<RectTransform>();

                var offsetMin = r.offsetMin;
                var offsetMax = r.offsetMax;
                var _anchorMin = r.anchorMin;
                var _anchorMax = r.anchorMax;

                var parent_width = p.rect.width;
                var parent_height = p.rect.height;

                var anchorMin = new Vector2(_anchorMin.x + (offsetMin.x / parent_width),
                                            _anchorMin.y + (offsetMin.y / parent_height));
                var anchorMax = new Vector2(_anchorMax.x + (offsetMax.x / parent_width),
                                            _anchorMax.y + (offsetMax.y / parent_height));

                r.anchorMin = anchorMin;
                r.anchorMax = anchorMax;

                r.offsetMin = new Vector2(0, 0);
                r.offsetMax = new Vector2(0, 0);
                r.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }
}