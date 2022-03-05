using static UnityEngine.InputSystem.InputAction;

namespace Game0.Interfaces
{
    public interface IInputable
    {
        /// <summary>Event source.</summary>
        UserInput inputs { get; set; }

        /// <summary>Click handler for left mouse button.</summary>
        /// <param name="context">CallbackContext as event context.</param>
        void OnMouseLeftButtonClickPanHandler(CallbackContext context);

        /// <summary>Click handler for right mouse button.</summary>
        /// <param name="context">CallbackContext as event context.</param>
        void OnMouseRightButtonClickPanHandler(CallbackContext context);

        /// <summary>Camera pan handler.</summary>
        /// <param name="context">CallbackContext as event context.</param>
        void OnCameraPanHandler(CallbackContext context);

        /// <summary>Camera rotation handler.</summary>
        /// <param name="context">CallbackContext as event context.</param>
        void OnCameraRotationHandler(CallbackContext context);

        /// <summary>Camera zoom handler.</summary>
        /// <param name="context">CallbackContext as event context.</param>
        void OnCameraZoomHandler(CallbackContext context);

        /// <summary>Subscribes to interested events.</summary>
        void Subscribe();

        /// <summary>Unsubscribes from interested events.</summary>
        void Unsubscribe();
    }
}