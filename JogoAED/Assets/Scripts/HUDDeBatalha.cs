using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDeBatalha : MonoBehaviour
{
    public Text nome; // nome do personagem, que aparece ao lado de sua barra de vida
    public Slider barraDeVida; // barra de vida do personagem

    // procedimento que seta os atributos do HUD (nome e barra de vida)
    public void SetHUD(Unidade unidade)
    {
        nome.text = unidade.nomeDaUnidade; // o nome no HUD se torna o nome do personagem
        barraDeVida.maxValue = unidade.vidaMaxima; // a barra de vida recebe a vida máxima do personagem
        barraDeVida.value = unidade.vidaAtual;
    }

    // procedimento que seta a vida no HUD
    public void SetVida(int hp)
    {
        barraDeVida.value = hp;
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BatalhaHUD : MonoBehaviour
{
    public Text textoDeNome;
    public Slider barraDeVida;

    public void SetarHUD(Unidade unidade)
    {
        textoDeNome.text = unidade.Nome;
        barraDeVida.maxValue = unidade.VidaMaxima;
        barraDeVida.value = unidade.VidaAtual;
    }

    public void SetarVida(int hp)
    {
        barraDeVida.value = hp;
    } 
}
*/