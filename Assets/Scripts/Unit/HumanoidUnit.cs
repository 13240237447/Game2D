using System;
using AI;
using UnityEngine;

public class HumanoidUnit : Unit
{
    private static readonly int MoveSpeed = Animator.StringToHash("moveSpeed");


    private Vector2 Velocity { set; get; }
    
    private Vector2 LastFramePosition { set; get; }

    public bool IsMoving {private set; get; }

    public float CurrSpeed => Velocity.magnitude;
    
    private void Update()
    {
        var position = transform.position;
        Velocity = (new Vector2(position.x - LastFramePosition.x, 
                        position.y - LastFramePosition.y) /
                    Time.deltaTime);
        LastFramePosition = position;
        IsMoving = Velocity.sqrMagnitude > 0;
        if (Animator != null)
        {
            Animator.SetFloat(MoveSpeed,CurrSpeed);
        }
    }

}