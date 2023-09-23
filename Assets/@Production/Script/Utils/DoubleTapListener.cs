using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

namespace Gtion.UI
{
    public class DoubleTapListener : MonoBehaviour, IPointerDownHandler
    {
        private float tapTime;
        private const float doubleTapTime = 0.3f; // Adjust this value based on your needs

        public UnityEvent OnDoubleTap;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Time.time - tapTime < doubleTapTime)
            {
                //unity action will never return null reference exception even if event is empty
                OnDoubleTap.Invoke();
            }
            tapTime = Time.time;
        }
    }
}