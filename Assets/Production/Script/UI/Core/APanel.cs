using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gtion.UI
{
    public enum PanelType
    { 
        Home,
        Discover,
        NewPost,
        Inbox,
        Account
    }
    public abstract class APanel : AMenuView
    {
        public abstract PanelType Type { get; }
    }
}