using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform posicaoJogador;

    // Update is called once per frame
    void Update()
    {
        if (posicaoJogador!= null)
        {
            transform.position = new Vector2(posicaoJogador.position.x, transform.position.y);
        }
    }
}
