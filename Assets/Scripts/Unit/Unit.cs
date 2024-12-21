using System;
using AI;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected Animator Animator {private set; get; }
 
    protected AIPawn AIPawn {private set; get; }
    
    protected SpriteRenderer SP { private set; get; }
    
    public bool IsSelect { private set; get; }

    private Material originMat;
    private void Awake()
    {
        if (TryGetComponent<Animator>(out var animator))
        {
            Animator = animator;
        }
        if (TryGetComponent<AIPawn>(out var aiPawn))
        {
            AIPawn = aiPawn;
        }

        if (TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            SP = spriteRenderer;
            originMat = SP.material;
        }
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        
    }

    public void MoveToTarget(Vector3 dest)
    {
        if (SP != null)
        {
            var dir = (dest - transform.position).normalized;
            SP.flipX = dir.x < 0;
        }
        if (AIPawn != null)
        {
            AIPawn.SetDestination(dest);
        }
    }

    public void Select()
    {
        IsSelect = true;
        SP.material = Game.Res.GetOutLineShader(this);
    }

    public void UnSelect()
    {
        IsSelect = false;
        SP.material = originMat;
    }
    
}