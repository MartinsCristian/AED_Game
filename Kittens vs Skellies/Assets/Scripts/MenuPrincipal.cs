using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        //Pega o indice da cena atual, soma 1 e depois carrega a cena do indice resultante
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Sair()
    {
        Debug.Log("Saiu!");
        Application.Quit();
    }
}
