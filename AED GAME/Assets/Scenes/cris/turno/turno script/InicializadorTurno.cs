using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InicializadorTurno : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject f;


    Unidade playerUnit;
	Unidade enemyUnit;
    FilaDeJogadores fila;
    void Start()
    {
        Debug.Log("alooo");
        GameObject playerGO = Instantiate(p1);
		playerUnit = playerGO.GetComponent<Unidade>();

        GameObject enemyGO = Instantiate(p2);
		enemyUnit = enemyGO.GetComponent<Unidade>();

        GameObject filaGO = Instantiate(f);
		fila = filaGO.GetComponent<FilaDeJogadores>();

        fila.insere(playerUnit);
        fila.insere(enemyUnit);

        fila.printDaMassa();

        
    }

}
