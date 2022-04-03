using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidade : MonoBehaviour
{
    public string nomeDaUnidade; // nome do personagem criado com esse TAD
	public float dano; // dano que esse personagem causa
	public int vidaMaxima; // vida máxima desse personagem
	public float vidaAtual; // vida atual desse personagem

    // método que faz o personagem tomar dano, ou seja, ter uma redução no valor de sua vida
	public bool TomarDano(float dano) {
		vidaAtual -= dano; // perde vida

		if (vidaAtual <= 0) // se morreu, retorna true
			return true;
		else // se não morreu, retorna false
			return false;
	}

    // procedimento que cura o personagem, ou seja, aumenta sua vida atual
	public void Curar(float quantidade) {
		vidaAtual += quantidade; // aumenta a quantidade em sua vida
		if (vidaAtual > vidaMaxima) // se ultrapassar a vida máxima do personagem
			vidaAtual = vidaMaxima; // então a vida atual se torna a vida máxima, pois não tem como ultrapassar sua vida máxima
	}
}
