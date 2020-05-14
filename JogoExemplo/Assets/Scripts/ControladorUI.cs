﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    public Text moedas;
    public Image[] coracoes;
    public Sprite coracaoVazio;
    public Sprite coracaoCheio;
    public int vidaAtual;
    public int vidaMaxima;
    public Jogador jogador;

    void Update()
    {
        vidaAtual = jogador.vidaAtual;
        vidaMaxima = jogador.vidaMaxima;
        
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i > vidaAtual - 1)
                coracoes[i].sprite = coracaoVazio;
            else
                coracoes[i].sprite = coracaoCheio;

            if (i < vidaMaxima )
                coracoes[i].enabled = true;
            else
                coracoes[i].enabled = false;
        }

        int quantidadeMoedas = jogador.quantidadeMoedas;
        moedas.text = "Moedas: ";
        moedas.text += quantidadeMoedas.ToString();
    }
}
