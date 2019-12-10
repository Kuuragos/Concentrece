using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mapeo_2 : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntos;
    int puntaje = 0;
    public static float reloj = 80f;
    bool contraReloj = true;
    public Material[] skins = new Material[16];
    public static GameObject tempo1, tempo2;
    public GameObject win, youLose;
    public static List<Material> myMaterial = new List<Material>();

    public GameObject fichas;
    public Dictionary<Material, nombre1> dik = new Dictionary<Material, nombre1>();
    private void Awake()
    {
        win.SetActive(false);
        youLose.SetActive(false);
        Diccionario();
    }
    void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            myMaterial.Add(skins[i]);
            myMaterial.Add(skins[i]);
        }


        Shuffle(ref myMaterial);

        for (int i = 0; i <= 31; i++)
        {
            fichas.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = myMaterial[i];
            fichas.transform.GetChild(i).GetChild(0).GetComponent<Rotar1>().myType = dik[myMaterial[i]];

        }
    }

    void Update()
    {
        puntos.text = "Puntos: " + puntaje;
        tiempo.text = "Tiempo: " + reloj.ToString("f0");

        if (reloj <= 0.0f)
        {
            contraReloj = false;
            Rotar1.juego = false;
            youLose.SetActive(true);

        }
        if (contraReloj == true)
        {
            reloj -= Time.deltaTime;

        }
       
        if (puntaje == 16)
        {
            contraReloj = false;
            Rotar1.juego = false;
            win.SetActive(true);

        }
    }

    public void Shuffle(ref List<Material> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Material valu = list[k];
            list[k] = list[n];
            list[n] = valu;

        }
    }
    public void Diccionario()
    {
        dik.Add(skins[0], nombre1.Antiguo);
        dik.Add(skins[1], nombre1.Arbol);
        dik.Add(skins[2], nombre1.Baldur);
        dik.Add(skins[3], nombre1.Brock);
        dik.Add(skins[4], nombre1.Casa);
        dik.Add(skins[5], nombre1.Dragon);
        dik.Add(skins[6], nombre1.Elfo);
        dik.Add(skins[7], nombre1.Freya);
        dik.Add(skins[8], nombre1.Kratos);
        dik.Add(skins[9], nombre1.Libro);
        dik.Add(skins[10], nombre1.Mimir);
        dik.Add(skins[11], nombre1.Orco);
        dik.Add(skins[12], nombre1.Serpiente);
        dik.Add(skins[13], nombre1.Sindri);
        dik.Add(skins[14], nombre1.Thor);
        dik.Add(skins[15], nombre1.Valkyria);

    }
    public void Rellenar(GameObject carta)
    {
        if (tempo1 == null)
        {
            tempo1 = carta;
        }
        else if (tempo1 != carta)
        {
            tempo2 = carta;
            Comprovar();
            Rotar1.lokc = true;
        }
    }
    public void Comprovar()
    {
        if (tempo1.GetComponent<Rotar1>().myType == tempo2.GetComponent<Rotar1>().myType)
        {
            Invoke("Destuir", 1f);

        }
        else
        {

            Invoke("Error", 0.7f);

        }
    }
    public void Destuir()
    {
        puntaje += 1;
        Destroy(tempo2);
        Destroy(tempo1);
        Rotar1.lokc = false;

    }
    public void Error()
    {
        tempo1.GetComponent<Rotar1>().show = false;
        tempo2.GetComponent<Rotar1>().show = false;
        tempo1 = null;
        tempo2 = null;
        Rotar1.lokc = false;

    }
}
public enum nombre1
{
    Antiguo, Arbol, Baldur, Brock, Casa, Dragon, Elfo, Freya, Kratos, Libro, Mimir, Orco, Serpiente, Sindri, Thor, Valkyria
}