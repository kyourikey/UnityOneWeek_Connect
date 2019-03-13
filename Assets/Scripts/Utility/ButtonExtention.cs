using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Utility
{
    public static class ButtonExtention
    {
        public static void OnPointerDown(this Button button, Action onClickAction)
        {
            AddEventTriggerEntry(button, onClickAction, EventTriggerType.PointerDown);
        }

        public static void OnPointerEnter(this Button button, Action onEnterAction)
        {
            AddEventTriggerEntry(button, onEnterAction, EventTriggerType.PointerEnter);
        }

        public static void OnPointerExit(this Button button, Action onExitAction)
        {
            AddEventTriggerEntry(button, onExitAction, EventTriggerType.PointerExit);
        }

        private static void AddEventTriggerEntry(Button button, Action action, EventTriggerType type)
        {
            var entry = new EventTrigger.Entry { eventID = type };
            entry.callback.AddListener(_ => { action();});
            var trigger = button.gameObject.GetComponent<EventTrigger>() ?? button.gameObject.AddComponent<EventTrigger>();
            trigger.triggers.Add(entry);
        }
    }
}
