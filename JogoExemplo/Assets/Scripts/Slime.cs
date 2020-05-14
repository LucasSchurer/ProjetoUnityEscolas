using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float tempoEntrePulos = 2f;
    private float contadorTempoEntrePulos = 0f;
    public float alturaPulo = 4f;
    public float tempoParaApicePulo = 0.4f;
    private float gravidade;
    private float velocidadePulo;
    private Vector2 velocidade;
    
    private Controlador2D controlador;

    void Awake()
    {
        controlador = GetComponent<Controlador2D>();

        gravidade = -(alturaPulo * 2) / Mathf.Pow(tempoParaApicePulo, 2);
        velocidadePulo = Mathf.Abs(gravidade) * tempoParaApicePulo;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlador.colisoes.abaixo)
            velocidade.y = 0f;

        if (contadorTempoEntrePulos <= 0 && controlador.colisoes.abaixo)
        {
            velocidade.y = velocidadePulo;

            contadorTempoEntrePulos = tempoEntrePulos;
        }

        if (contadorTempoEntrePulos > 0)
            contadorTempoEntrePulos -= Time.deltaTime;
            

        velocidade.y += gravidade * Time.deltaTime;
        controlador.Mover(velocidade * Time.deltaTime);
    }
}
