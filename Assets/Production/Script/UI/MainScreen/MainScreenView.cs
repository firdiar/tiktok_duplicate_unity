using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gtion.UI
{
    public class MainScreenView : AMenuView
    {
        [SerializeField]
        List<APanel> panels = new List<APanel>();

        public void SetActivePanel(PanelType panelType)
        {
            if (panelType == PanelType.NewPost)
            {
                //special execution for new post!

            }
            else
            { 
                
            }
        }
    }
}
