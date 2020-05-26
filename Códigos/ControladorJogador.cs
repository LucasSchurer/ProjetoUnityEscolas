using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe para controlar as ações do jogador (andar, pular, etc...).
// Obs: Essa classe NÃO move o jogador, apenas pede para outra classe realizar a movimentação.
// Pense mais como uma classe que manda outras realizarem ações (caso fosse atacar, chamaria um ControladorCombate, por exemplo).
public class ControladorJogador : MonoBehaviour
{
    // Nosso objeto para acessar o componente ControladorMovimentacao presente no Jogador.
    private ControladorMovimentacao controladorMovimentacao;
    // Um valor float para nossa velocidade de movimento, o quão rápido nosso jogador se movimenta.
    public float velocidadeMovimento = 1000f;
    // Altura que nosso jogador pula.
    public float alturaPulo = 5000f;

    // A função Start é uma função nativa do Unity executada sempre ANTES do primeiro frame do jogo, ou seja, antes do jogo "começar".
    void Start()
    {
        // Falamos que nosso controladorMovimentacao é igual ao componente ControladorMovimentacao presente no nosso Jogador.
        // Caso isso não existisse, nosso controladorMovimentacao não seria "nada", ele não saberia quem ele é.
        controladorMovimentacao = GetComponent<ControladorMovimentacao>();
    }

    // Update é também uma função nativa do Unity, chamada todo frame.
    void Update()
    {
        // Criamos uma nova variável chamada direcao, que vai armazenar se estamos indo para a direita (1), para a esquerda (-1), ou se estamos parados (0).
        float direcao = 0f;

        // Checamos se estamos com a seta esquerda do mouse apertada.
        // se ( tecla (tecla esquerda) )
        // Input é uma classe com um método (ou função) chamada GetKey. 
        // GetKey necessita de uma tecla como argumento (O nosso KeyCode.LeftArrow).
        // Caso quisesse outra tecla, você poderia usar KeyCode.A (para o A), KeyCode.D (para o D), etc...
        // https://docs.unity3d.com/ScriptReference/KeyCode.html
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Quando a seta esquerda for apertada, vamos diminuir -1f da nossa direção.
            direcao -= 1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Quando a seta direita for apertada, vamos diminuir -1f da nossa direção.
            direcao += 1f;
        }

        // Input.GetKeyDown checa se uma determinada tecla FOI apertada. Ideal para todas as ações que não são de movimentação (para a direita ou esquerda).
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Chamamos nossa função de Pular dentro do controladorMovimentacao.
            controladorMovimentacao.Pular(alturaPulo * Time.deltaTime);
        }

        // Chamamos nossa função de Mover dentro do controladorMovimentacao.
        controladorMovimentacao.Mover(direcao * velocidadeMovimento * Time.deltaTime);
    }
}
