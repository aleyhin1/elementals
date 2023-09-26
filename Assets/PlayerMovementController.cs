using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : NetworkBehaviour
{
    private Camera _camera;
    private Transform _bodyTransform;

    public override void Spawned()
    {
        _camera = FindObjectOfType<Camera>();
        _bodyTransform = GetComponentInChildren<Transform>();
    }

    public override void FixedUpdateNetwork()
    {
        Look();
    }

    private void Look()
    {
        Vector3 rotationVector = new Vector3(0, 0, GetTurnAngle());
        _bodyTransform.eulerAngles = rotationVector;
    }

    private float GetTurnAngle()
    {
        Vector2 directionVector = (GetMousePositionWorldPoint() - (Vector2)transform.position).normalized;
        float turnAngle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
        return turnAngle;
    }

    private Vector2 GetMousePositionWorldPoint()
    {
        var inputData = Runner.GetInputForPlayer<PlayerInput>(Object.InputAuthority);
        Vector2 mousePositionWorldPoint = _camera.ScreenToWorldPoint(inputData.Value.MousePosition);
        return mousePositionWorldPoint;
    }
}
