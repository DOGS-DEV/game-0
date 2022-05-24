using System;
using UnityEngine;

namespace Game0 {
    
    public class EventManager
    {
        public static Action<Vector2> OnMove;
        public static Action OnSpace;
        public static Action OnLMBClick;
        public static Action<bool> OnRMBClick;

        public static void SendMoving(Vector2 destination)
        {
            Debug.Log("SendMoving!");
            if (OnMove == null) return;
            OnMove.Invoke(destination);
        }

        public static void SendSpace() {
            Debug.Log("SendSpace!");
            if (OnSpace == null) return;
            OnSpace.Invoke();
        }

        public static void SendLMBClick()
        {
            Debug.Log("SendLMBClick!");
            if (OnLMBClick == null) return;
            OnLMBClick.Invoke();
        }

        public static void SendRMBClick(bool flag)
        {
            Debug.Log("SendRMBClick!");
            if (OnRMBClick == null) return;
            OnRMBClick.Invoke(flag);
        }
    }
}