using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : NetworkBehaviour
{
    private Camera _camera;
    private Animator _animator;

    private float _mousePositionY;
    private float positionY;
    private float _horizontalInput;
    private float _verticalInput;


    public override void Spawned()
    {
        _camera = FindAnyObjectByType<Camera>();
        _animator = GetComponentInChildren<Animator>();
    }

    public override void Render()
    {
        _animator.SetBool("IsTurnedBack", (_mousePositionY - positionY) > 0);
        _animator.SetBool("IsRunningVertically", _verticalInput != 0);
    }

    public override void FixedUpdateNetwork()
    {
        GetInputs();
    }
    
    private void GetInputs()
    {
        GetInput<PlayerInput>(out var input);
        _mousePositionY = _camera.ScreenToWorldPoint(input.MousePosition).y;
        positionY = transform.position.y;
        _horizontalInput = input.HorizontalInput;
        _verticalInput = input.VerticalInput;
    }
}
