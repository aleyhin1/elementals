using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum PlayerButtons
{
    Attack = 0,
    Defense = 1,
}

public struct PlayerInput : INetworkInput
{
    public Vector2 MousePosition;
    public float HorizontalInput;
    public float VerticalInput;
    public NetworkButtons PlayerButtons;
}
