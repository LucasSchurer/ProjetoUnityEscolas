using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controlador2D), typeof(Rigidbody2D))]
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

    public int vidaAtual = 3;
    public int vidaMaxima = 3;

    public Direcao direcaoOlhar = Direcao.Direita;

    public ControladorJogo controladorJogo;

    public int quantidadeMoedas = 0;

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
        
        if (controlador.colisoes.abaixo)
            velocidade.y = 0f;
        

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

        AtualizarDirecao(inputHorizontal);
    }

    // Método que é ativado toda vez que nosso personagem tem contato com outros objetos.
    void OnTriggerEnter2D(Collider2D objeto)
    {
        // Se nosso objeto possuír a tag Inimigo podemos realizar mais coisas
        if (objeto.tag == "Inimigo")
        {
            // Mostra no console o nome do objeto
            print(objeto.name);    

            // Caso a nossa posição y for maior que a posição y do nosso inimigo, vamos matá-lo e dar um pulo.
            if ((transform.position.y - controlador.colisor.size.y/2) > objeto.transform.position.y)
            {
                objeto.gameObject.SendMessage("ReceberDano", 1);
                velocidade.y = velocidadePulo;
                controlador.Mover(velocidade * Time.deltaTime);
            }
            else
                ReceberDano(1);
        }

        if (objeto.tag == "FimFase")
        {
            controladorJogo.AvancarNivel();
        }

        if (objeto.tag == "Moeda")
        {
            quantidadeMoedas++;
            Destroy(objeto.gameObject);
        }
    }

    // Método onde podemos receber dano e também levar um empurrão na direção contrária do inimigo ao ser atingido.
    public void ReceberDano(int quantidadeDano)
    {
        // Remove nossa vida e checa se não morremos
        vidaAtual -= quantidadeDano;

        if (vidaAtual <= 0)
            Morrer();

        // Movemos nosso jogador para a direção contrária de onde está olhando ao receber dano.
        float forcaRecuo = 15f;
        velocidade.x = forcaRecuo * (direcaoOlhar == Direcao.Direita ? -1 : 1);
    }

    private void Morrer()
    {
        Destroy(this.gameObject);
    }

    private void AtualizarDirecao(float inputHorizontal)
    {
        // Caso estejamos nos movimentando para direita rotacione para direita (apenas se não estava olhando para lá em primeiro lugar!)
        if (inputHorizontal == 1)
        {
            // Se não estivermos olhando para a direita, gira nosso personagem para a direita e atualiza nosso olharDirecao.
            if (direcaoOlhar != Direcao.Direita)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);   
                direcaoOlhar = Direcao.Direita;
            }
                
        } 
        else if (inputHorizontal == -1)
        {
            // Se não estivermos olhando para a esquerda, gira nosso personagem a esquerda e atualiza nosso olharDirecao.
            if (direcaoOlhar != Direcao.Esquerda)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                direcaoOlhar = Direcao.Esquerda;
            }
        }
    }
}

public enum Direcao { Direita, Esquerda };