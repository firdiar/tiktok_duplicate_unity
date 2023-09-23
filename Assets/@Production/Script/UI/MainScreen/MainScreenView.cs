using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gtion.UI
{
    public class MainScreenView : AMenuView
    {
        [SerializeField]
        List<APanel> panels = new List<APanel>();

        [SerializeField]
        NewPostPanel newPostPanel;

        public void SetActivePanel(PanelType panelType)
        {
            if (panelType == PanelType.NewPost)
            {
                //special execution for new post!
                newPostPanel.Show();
            }
            else
            { 
                foreach(APanel panel in panels) 
                {
                    if (panel.Type == panelType)
                    {
                        panel.Show();
                    }
                    else
                    {
                        panel.Hide();
                    }
                }
            }
        }
    }
}
