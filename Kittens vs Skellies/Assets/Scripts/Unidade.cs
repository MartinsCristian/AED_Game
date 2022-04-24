using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidade : MonoBehaviour
{
    public string nomeDaUnidade; // nome do personagem criado com esse TAD
    public int dano; // dano que esse personagem causa
    public int vidaMaxima; // vida m�xima desse personagem
    public int vidaAtual; // vida atual desse personagem

    // m�todo que faz o personagem tomar dano, ou seja, ter uma redu��o no valor de sua vida
    public bool TomarDano(int dano)
    {
        vidaAtual -= dano; // perde vida

        if (vidaAtual <= 0) // se morreu, retorna true
            return true;
        else // se n�o morreu, retorna false
            return false;
    }

    // procedimento que cura o personagem, ou seja, aumenta sua vida atual
    public void Curar(int quantidade)
    {
        vidaAtual += quantidade; // aumenta a quantidade em sua vida
        if (vidaAtual > vidaMaxima) // se ultrapassar a vida m�xima do personagem
            vidaAtual = vidaMaxima; // ent�o a vida atual se torna a vida m�xima, pois n�o tem como ultrapassar sua vida m�xima
    }
}
