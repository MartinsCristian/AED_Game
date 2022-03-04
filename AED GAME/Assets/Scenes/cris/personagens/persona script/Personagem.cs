using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    ////variaveis////
    private int iniciativa; //posicao na fila dos turnos
    private int vida = 20;
    private char tipo = 'g'; //tipos de personagem
    private int nome = 0;
    /*
    g = guerreiro
    a = arqueiro
    m = mago
    c = curandeiro
    */

    ////metodos////
    public Personagem()
    {
        nome = nome++;
    }
    public int getIniciativa()
    {
        return this.iniciativa;
    }
    void Start()
    {
        //set iniciativa
        this.iniciativa = Random.Range(1,20);
    }

}
