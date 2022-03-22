using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaDeJogadores : MonoBehaviour
{
    private JogadorAbstrato header;
    private  JogadorAbstrato current;

    public void insere(Unidade newPlayer)
    {
        if (header == null)
        {
            header = new JogadorAbstrato();
            header.player = newPlayer;
            header.next = null;
        }
        else
        {
            JogadorAbstrato adcionar = new JogadorAbstrato();
            adcionar.player = newPlayer;

            current = header;

            while(current.next != null)
            {
                current = current.next;
            }
            current.next = adcionar;
        }
    }
    public void remove(Unidade newPlayer)
    {

    }

    public void printDaMassa()
    {
        current = header;
        while (current != null)
        {
            Debug.Log(current.player.unitName);
            current = current.next;
        }
    }

}
