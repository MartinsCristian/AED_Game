using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDeBatalha : MonoBehaviour
{
    public Text nome; // nome do personagem, que aparece ao lado de sua barra de vida
	public Image barraDeVida; // barra de vida do personagem

    // procedimento que seta os atributos do HUD (nome e barra de vida)
	public void SetHUD(Unidade unidade)
	{
		nome.text = unidade.nomeDaUnidade; // o nome no HUD se torna o nome do personagem
		barraDeVida.fillAmount = unidade.vidaMaxima; // a barra de vida recebe a vida máxima do personagem
	}

    // procedimento que seta a vida no HUD
	public void SetVida(Unidade unidade)
	{
		barraDeVida.fillAmount = unidade.vidaAtual / unidade.vidaMaxima;
	}
}
