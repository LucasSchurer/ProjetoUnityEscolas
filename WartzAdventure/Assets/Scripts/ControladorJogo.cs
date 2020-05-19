using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJogo : MonoBehaviour
{
    public int nivelAtual = 1;
    
    public void MudarNivel(int nivelDesejado)
    {
        switch(nivelDesejado)
        {   
            case -1: 
            {
                // Informações adicionais sobre o jogo
                SceneManager.LoadScene("Nivel-1");
                nivelAtual = -1;
                break;
            }

            case 0:
            {
                // Menu inicial     
                SceneManager.LoadScene("Nivel0");
                nivelAtual = 0;   
                break;
            }

            case 1:
            {
                // Nível 1
                SceneManager.LoadScene("Nivel1");
                nivelAtual = 1;
                break;
            }

            case 2:
            {
                // Nível 2
                SceneManager.LoadScene("Nivel2");
                nivelAtual = 2;
                break;
            }

            default:
            {
                SceneManager.LoadScene("Nivel0");
                nivelAtual = 0;
                break;
            }
        }
    }

    public void AvancarNivel()
    {
        MudarNivel(nivelAtual + 1);
    }
}
