using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMovimentacao : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Mover(float velocidade)
    {
        // Vector2 é um tipo que vai se parecer com coordenadas (X, Y).
        // Como estamos nos movendo para a direita ou esquerda, criamos um novo Vector2 e mudamos o X para ser igual a nossa velocidade, deixando o Y = 0.
        // Vector2 vai ser melhor explicado nas próximas aulas.
        rb.AddForce(new Vector2(velocidade, 0));
    }

    public void Pular(float velocidade)
    {
        rb.AddForce(new Vector2(0, velocidade));
    }
}
