using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorAbstrato
{
    //node
    public JogadorAbstrato next;
    //data
    public Unidade player;
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemAbstrato : MonoBehaviour
{
    private PersonagemAbstrato proximo;
    private Unidade personagem;

    public PersonagemAbstrato Proximo
    {
        get { return proximo; }
        set { proximo = value; }
    }

    public Unidade Personagem
    {
        get { return personagem; }
        set { personagem = value; }
    }

}
*/
