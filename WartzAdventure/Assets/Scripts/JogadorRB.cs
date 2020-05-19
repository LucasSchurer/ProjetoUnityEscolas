using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorRB : MonoBehaviour
{
    private ControladorRB2D controlador;

    public float velocidadeMovimento;
    public float alturaPulo;

    void Awake()
    {
        controlador = GetComponent<ControladorRB2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float entradaHorizontal = Input.GetAxisRaw("Horizontal");
        float movimentoHorizontal = entradaHorizontal * velocidadeMovimento;

        controlador.Mover(movimentoHorizontal * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            controlador.Pular(alturaPulo);
    }
}
