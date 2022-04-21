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
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidade : MonoBehaviour
{
    //Variaveis
    public string nomeDaUnidade;
    public int danoDaUnidade;

    public int vidaMaxima;
    public int vidaAtual;

    //Metodos
    public int VidaMaxima
    {
        get { return vidaMaxima; }
        set { vidaMaxima = value; }
    }

    public int VidaAtual
    {
        get { return vidaAtual; }
        set { vidaAtual = value; }
    }

    public int Dano
    {
        get { return danoDaUnidade; }
        set { danoDaUnidade = value; }
    }

    public string Nome
    {
        get { return nomeDaUnidade; }
        set { nomeDaUnidade = value; }
    }

    public bool TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
            return true;

        return false;
    }

    public void Curar(int quantidade)
    {
        vidaAtual += quantidade;

        if(vidaAtual > vidaMaxima)
            vidaAtual = vidaMaxima;

    }
}
*/