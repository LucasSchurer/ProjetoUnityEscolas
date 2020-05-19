using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBotao : ControladorMoeda
{
    public bool foiSelecionado = false;
    public int fase;
    public ControladorJogo controladorJogo;
   
    void Update()
    {
        if (!foiSelecionado)
        {
            Flutuar();
        }
        else
        {
            transform.Translate(Vector2.down * 10f * Time.deltaTime);
        }
    }

    public void Selecionar()
    {
        foiSelecionado = true;
        StartCoroutine(SelecionaNivelAposSegundos(0.5f));
    }

    IEnumerator SelecionaNivelAposSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        controladorJogo.MudarNivel(fase);
        Destroy(this.gameObject);
    }
}
