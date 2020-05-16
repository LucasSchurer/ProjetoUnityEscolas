using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMoeda : MonoBehaviour
{
    public Vector2 velocidade;
    public float tempoMovimentacao = 1.5f;
    public float timer = 0f;
    public bool estaDescendo;

    void Update()
    {
        if (timer <= 0)
        {
            timer = tempoMovimentacao;
            estaDescendo = !estaDescendo;
        } else
        {
            timer -= Time.deltaTime;
        }

        velocidade = (estaDescendo ? Vector2.down : Vector2.up) * 0.2f * Time.deltaTime;
        transform.Translate(velocidade);
    }
}
