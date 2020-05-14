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
            case 0:
            {
                // Menu inicial        
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

            case 3:
            {
                // Nível 3
                break;
            }
        }
    }

    public void AvancarNivel()
    {
        MudarNivel(nivelAtual + 1);
    }
}
