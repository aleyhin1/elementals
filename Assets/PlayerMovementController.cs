using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Camera _camera;

    public override void Spawned()
    {
        _camera = FindObjectOfType<Camera>();
    }

    public override void FixedUpdateNetwork()
    {
        Look();
        Move();
    }

    private void Look()
    {
        Vector3 rotationVector = new Vector3(0, 0, GetTurnAngle());
        transform.eulerAngles = rotationVector;
    }

    private void Move()
    {
        var inputData = Runner.GetInputForPlayer<PlayerInput>(Object.InputAuthority);
        Vector2 movementVector = new Vector2(inputData.Value.HorizontalInput, inputData.Value.VerticalInput);
        transform.Translate(movementVector * _speed * Runner.DeltaTime);
    }

    private float GetTurnAngle()
    {
        Vector2 directionVector = (GetMousePositionWorldPoint() - (Vector2)transform.position).normalized;
        float directionAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
        float offsetAngle = -90f;
        float turnAngle = directionAngle + offsetAngle;
        return turnAngle;
    }

    private Vector2 GetMousePositionWorldPoint()
    {
        var inputData = Runner.GetInputForPlayer<PlayerInput>(Object.InputAuthority);
        Vector2 mousePositionWorldPoint = _camera.ScreenToWorldPoint(inputData.Value.MousePosition);
        return mousePositionWorldPoint;
    }
}
