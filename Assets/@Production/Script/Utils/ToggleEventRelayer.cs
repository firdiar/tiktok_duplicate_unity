using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gtion.UI
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleEventRelayer : MonoBehaviour
    {
        public UnityEvent OnToggleActive;
        public void OnActiveChange(bool isActive)
        {
            if (isActive)
            {
                OnToggleActive?.Invoke();
            }
        }
    }
}
