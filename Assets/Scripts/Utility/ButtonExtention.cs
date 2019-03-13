using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Utility
{
    public static class ButtonFunctionExpansion
    {
        public static void OnPointerDown(this Button button, Action onPointerDownAction)
        {
            SetEventTrigger(button, onPointerDownAction, EventTriggerType.PointerDown);
        }

        public static void OnPointerEnter(this Button button, Action onPointerEnterAction)
        {
            SetEventTrigger(button, onPointerEnterAction, EventTriggerType.PointerEnter);
        }

        public static void OnPointerExit(this Button button, Action onPointerExitAction)
        {
            SetEventTrigger(button, onPointerExitAction, EventTriggerType.PointerExit);
        }

        private static void SetEventTrigger(Button button, Action action, EventTriggerType eventTriggerType)
        {
            var eventTriggerEntry = new EventTrigger.Entry { eventID = eventTriggerType };
            eventTriggerEntry.callback.AddListener(_ => action());
            var eventTrigger = button.gameObject.GetComponent<EventTrigger>() ?? button.gameObject.AddComponent<EventTrigger>();
            eventTrigger.triggers.Add(eventTriggerEntry);
        }
    }
}
