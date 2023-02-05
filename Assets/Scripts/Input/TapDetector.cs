using System;
using UnityEngine.EventSystems;

namespace Pirasapi
{
    public class TapDetector : Activatable, IPointerDownHandler, IPointerUpHandler
    {
        public Action OnTap;
        public Action OnRelease;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsActive)
                OnTap?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsActive)
                OnRelease?.Invoke();
        }

        protected override void Tick()
        {
        }
    }
}
