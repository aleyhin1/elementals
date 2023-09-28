using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour
{
    [SerializeField] private float _speed = 1f;

    public override void FixedUpdateNetwork()
    {
        Move();
    }

    private void Move()
    {
        var inputData = Runner.GetInputForPlayer<PlayerInput>(Object.InputAuthority);
        Vector2 movementVector = new Vector2(inputData.Value.HorizontalInput, inputData.Value.VerticalInput);
        transform.Translate(movementVector.normalized * _speed * Runner.DeltaTime);
    }
}
