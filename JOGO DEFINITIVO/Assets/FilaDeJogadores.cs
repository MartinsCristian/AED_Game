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
            JogadorAbstrato adicionar = new JogadorAbstrato();
            adicionar.player = newPlayer;

            current = header;

            while(current.next != null)
            {
                current = current.next;
            }
            current.next = adicionar;
        }
    }
    public void remove() {
        if (header != null) {
            this.insere(header.player);
            header = header.next;
        }
    }

    public JogadorAbstrato getHeader() {
        return this.header;
    }

    public Unidade getPlayer() {
        return this.header.player;
    }

/*
    public void printDaMassa()
    {
        current = header;
        while (current != null)
        {
            Debug.Log(current.player.nomeDaUnidade);
            current = current.next;
        }
    }
*/
}