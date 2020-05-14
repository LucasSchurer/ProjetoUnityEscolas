using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float alturaPulo = 4f;
    public float tempoParaApicePulo = 0.4f;
    public float tempoAceleracaoNoAr = .2f;
	public float tempoAceleracaoNoChao = .1f;
    public float velocidadeMovimento = 20f;

    private float gravidade;
    private float velocidadePulo;
    private Vector2 velocidade;
    private float suavizacaoXVelocidade;

    private Controlador2D controlador;

    public bool estaNoChao;

    // Start is called before the first frame update
    void Awake()
    {
        controlador = GetComponent<Controlador2D>();

        // Você consegue entender o que estamos fazendo abaixo?
        // Dica: S = S0 + v0.t + (a.t²)/2
        // Dica: v = v0 + at
        gravidade = -(alturaPulo * 2) / Mathf.Pow(tempoParaApicePulo, 2);
        velocidadePulo = Mathf.Abs(gravidade) * tempoParaApicePulo;
    }

    // Update is called once per frame
    void Update()
    {
        // Experimente o código e depois remova o comentário do trecho abaixo. Consegue notar o que mudou? *Para remover múltiplas linhas remova o /* e o */.
        /*
        if (controlador.colisoes.abaixo)
            velocidade.y = 0f;
        */

        // Armazena o estado do personagem em um atributo dessa classe. Você consegue visualizar ele no Inspector enquanto o jogo roda :D Útil para entender se a sua movimentação está correta.
        estaNoChao = controlador.colisoes.abaixo;

        // Armazena os Inputs verticais do jogador (a, d, seta para esquerda e direita)
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        // Checa se a seta para cima foi apertada e se o jogador está no chão. Caso tudo seja verdadeiro, modifique nossa velocidade.y para podermos pular.
        // https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/operators/boolean-logical-operators
        // http://www.inf.ufpr.br/cursos/ci067/Docs/NotasAula/notas-6_Operadores_Logicos.html
        if(Input.GetKeyDown(KeyCode.UpArrow) && controlador.colisoes.abaixo)
            velocidade.y = velocidadePulo;

        // Você consegue entender o que o código abaixo faz?
        // Tente substituír as duas linhas abaixo por a seguinte:
        // velocidade.x = inputHorizontal * velocidadeMovimento;
        // Você nota alguma diferença?
        float velocidadeAlvoX = inputHorizontal * velocidadeMovimento;
		velocidade.x = Mathf.SmoothDamp(velocidade.x, velocidadeAlvoX, ref suavizacaoXVelocidade, controlador.colisoes.abaixo ? tempoAceleracaoNoChao : tempoAceleracaoNoAr);

        // Adiciona nossa gravidade à velocidade.y
        velocidade.y += gravidade * Time.deltaTime;

        // E finalmente move nosso personagem.
        controlador.Mover(velocidade * Time.deltaTime);
    }
}
