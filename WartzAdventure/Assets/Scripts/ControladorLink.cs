using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorLink : ControladorMoeda
{
    public bool foiSelecionado;
    public string link;
   
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
        if (!foiSelecionado)
        {
            foiSelecionado = true;
            StartCoroutine(LevaURLAposSegundos(1f));
        }
    }

    IEnumerator LevaURLAposSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        Application.OpenURL(link);
        Destroy(this.gameObject);
    }
}
