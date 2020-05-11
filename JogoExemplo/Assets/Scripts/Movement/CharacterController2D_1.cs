using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class CharacterController2D_1 : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;

    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalMovement)
    {
        rb.AddForce(new Vector2(horizontalMovement, 0));
    }

    public void Jump(float jumpHeight)
    {
        rb.AddForce(new Vector2(0, jumpHeight));
    }
}
