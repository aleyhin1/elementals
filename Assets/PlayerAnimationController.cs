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


    public override void Spawned()
    {
        _camera = FindAnyObjectByType<Camera>();
        _animator = GetComponentInChildren<Animator>();
    }

    public override void Render()
    {
        if ((_mousePositionY - positionY) > 0)
        {
            _animator.SetBool("IsTurnedBack", true);
        }
        else
        {
            _animator.SetBool("IsTurnedBack", false);
        }
    }

    public override void FixedUpdateNetwork()
    {
        GetInput<PlayerInput>(out var input);
        _mousePositionY = _camera.ScreenToWorldPoint(input.MousePosition).y;
        positionY = transform.position.y;
    }
}
