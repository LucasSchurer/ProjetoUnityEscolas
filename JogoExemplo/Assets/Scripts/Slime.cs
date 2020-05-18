using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controlador2D))]
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

    public int vida = 1;

    public bool estaParado = true;
    public bool estaPulando = false;
    public bool estaCaindo = false;

    private Animator animador;

    void Awake()
    {
        controlador = GetComponent<Controlador2D>();
        animador = GetComponent<Animator>();

        gravidade = -(alturaPulo * 2) / Mathf.Pow(tempoParaApicePulo, 2);
        velocidadePulo = Mathf.Abs(gravidade) * tempoParaApicePulo;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlador.colisoes.abaixo || controlador.colisoes.acima)
            velocidade.y = 0f;

        if (contadorTempoEntrePulos <= 0 && controlador.colisoes.abaixo)
        {
            velocidade.y = velocidadePulo;

            contadorTempoEntrePulos = tempoEntrePulos;
        }

        if (contadorTempoEntrePulos > 0)
            contadorTempoEntrePulos -= Time.deltaTime;
            
        if (controlador.colisoes.abaixo)
        {
            estaPulando = false;
            estaParado = true;
            estaCaindo = false;
        } 
        else if (velocidade.y <= 0)
        {
           estaPulando = false;
           estaParado = false; 
           estaCaindo = true;
        } 
        else
        {
            estaPulando = true;
            estaParado = false;
            estaCaindo = false;
        }

        animador.SetBool("estaParado", estaParado);
        animador.SetBool("estaPulando", estaPulando);
        animador.SetBool("estaCaindo", estaCaindo);
        
        velocidade.y += gravidade * Time.deltaTime;
        controlador.Mover(velocidade * Time.deltaTime);
    }

    public void ReceberDano(int quantidadeDano)
    {
        vida -= quantidadeDano;

        if (vida <= 0)
            Morrer();
    }

    private void Morrer()
    {
        Destroy(this.gameObject);
    }
}
