using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Nivel_1()
    {
        SceneManager.LoadScene("Facil");
        Mapeo.reloj = 90f;
    }

    public void Nivel_2()
    {
        SceneManager.LoadScene("Dificil");
        Rotar1.juego = true;
        Mapeo_2.reloj = 80f;
    }
    public void Indice()
    {
        SceneManager.LoadScene("Menu");
    }
}
