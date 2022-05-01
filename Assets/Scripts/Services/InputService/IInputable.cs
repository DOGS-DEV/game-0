using System;
using UnityEngine;

namespace Game0 {

    public interface IInputable
    {
        event EventHandler<Vector2> MovingEvent;
    }
}

