using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mapeo : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntos;
    int puntaje = 0;
    public static float reloj = 90f;
    bool contraReloj = true;
    public Material[] skins = new Material[8];
    public static GameObject tempo1, tempo2;
    public GameObject win, youLose;
    public static List<Material> myMaterial = new List<Material>();

   public  GameObject fichas;
   public Dictionary<Material, nombre> dic = new Dictionary<Material, nombre>();
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

        for (int i = 0; i <= 15; i++)
        {
            fichas.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = myMaterial[i];
            fichas.transform.GetChild(i).GetChild(0).GetComponent<Rotar>().myType = dic[ myMaterial[i]];

        }
    }

    void Update()
    {
        puntos.text = "Puntos: " + puntaje;
        tiempo.text = "Tiempo: " + reloj.ToString("f0");
        if (contraReloj == true)
        {
            reloj-=  Time.deltaTime;

        }
        if (reloj <= 0.0f)
        {
            contraReloj = false;
            Rotar.juego = false;

            youLose.SetActive(true);

        }
        if (puntaje == 8)
        {
            contraReloj = false;
            Rotar.juego = false;
            win.SetActive(true);

        }
    }

    public void Shuffle(ref List<Material> list)
    {
        int n = list.Count;
        while(n>1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Material valu = list[k];
            list[k] = list[n];
            list[n] = valu;

        }
    }
    public void Diccionario ()
    {
        dic.Add(skins[0], nombre.Bird);
        dic.Add(skins[1], nombre.Bull);
        dic.Add(skins[2], nombre.Dragon);
        dic.Add(skins[3], nombre.Hawk);
        dic.Add(skins[4], nombre.Head);
        dic.Add(skins[5], nombre.Man);
        dic.Add(skins[6], nombre.ManS);
        dic.Add(skins[7], nombre.Owl);

    }
    public void Rellenar(GameObject carta)
   {
        if(tempo1== null)
        {
            tempo1 = carta;
        }
        else if(tempo1 != carta)
        {
            tempo2 = carta;
            Comprovar();
            Rotar.lokc = true;
        }
   }
    public void Comprovar()
    {
        if (tempo1.GetComponent<Rotar>().myType==tempo2.GetComponent<Rotar>().myType)
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
        Rotar.lokc = false;

    }
    public void Error()
    {
        tempo1.GetComponent<Rotar>().show = false;
        tempo2.GetComponent<Rotar>().show = false;
        tempo1 = null;
        tempo2 = null;
        Rotar.lokc = false;

    }
}
public enum nombre
{
   Bird,Bull,Dragon,Hawk,Head,Man,ManS,Owl 
}