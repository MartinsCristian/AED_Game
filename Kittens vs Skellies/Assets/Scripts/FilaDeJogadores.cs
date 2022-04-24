using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaDeJogadores : MonoBehaviour
{
    private JogadorAbstrato header;
    private JogadorAbstrato current;


    //insere a unidade na fila.
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

            while (current.next != null)
            {
                current = current.next;
            }
            current.next = adicionar;
        }
    }

    //anda a fila e insere o primeiro no final
    public void remove()
    {
        if (header != null)
        {
            this.insere(header.player);
            header = header.next;
        }
    }

    //pega o header
    public JogadorAbstrato getHeader()
    {
        return this.header;
    }

    //pega a unidade armazenada no header
    public Unidade getPlayer()
    {
        return this.header.player;
    }

}
