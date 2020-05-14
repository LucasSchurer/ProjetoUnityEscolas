using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorRB2D : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Mover(float movimentoHorizontal)
    {
        rb.AddForce(new Vector2(movimentoHorizontal, 0));
    }

    public void Pular(float alturaPulo)
    {
        rb.AddForce(new Vector2(0, alturaPulo));
    }
}
