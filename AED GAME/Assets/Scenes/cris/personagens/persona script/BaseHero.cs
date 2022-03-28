using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseHero
{
    //coisas basicas
    public string name;
    public float baseHP;
    public float currentHP;
    public int iniciativa;

    //extras
    public int dexterity;
    public int agility;

    //classes
    public enum Tipo
    {
        GUERREIRO,
        MAGO,
        ARQUEIRO,
        CURANDEIRO
    }
    public Tipo tipoPersonagem;

}
