using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(x, y).normalized;
        if (move.sqrMagnitude > 0)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + (move * moveSpeed * Time.deltaTime));
        }
    }
}
