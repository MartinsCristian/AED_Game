using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a fila deve ser circular//
public class FilaTurnos : MonoBehaviour
{
    ////variaveis////
    private Personagem primeiro;
    private Personagem ultimo;
    private Personagem proximo;
    private Personagem anterior;
    private Personagem[] fila;

    ////metodos////
    //inicializador
    public FilaTurnos()
    {
        //this.fila = {} // implementando a fila com objetos criados
        this.fila = Ordenador();
    }

    public Personagem[] Ordenador()
    {
        //ordenando a fila
        for(int i = 0; i < 8; i++)
        {
            if((i-1)>0)
            {
                //quem tiver maior iniciativa vai primeiro
                if (this.fila[i].getIniciativa() > this.fila[i-1].getIniciativa())
                {
                    this.primeiro = this.fila[i];
                    this.proximo = this.fila[i+1];
                }
                //a menor fica em ultimo
                if (this.fila[i].getIniciativa() < this.fila[i-1].getIniciativa())
                {
                    this.ultimo = this.fila[i];
                }
            }
            
        }
        return this.fila;
    }

    public bool PassarTurno(bool passou)
    {
        Personagem aux = new Personagem();

        if (passou)
        {
            aux = this.primeiro;
            this.primeiro = this.proximo;
            this.ultimo = aux;

            return true;
        }
        else
            return false;
    }




    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            Debug.Log(this.fila[i]);
        }

    }


}
