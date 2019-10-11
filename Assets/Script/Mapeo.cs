using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeo : MonoBehaviour
{
    public Material[] skins = new Material[8];

    public static List<Material> myMaterial = new List<Material>();

    public  GameObject fichas;
   public Dictionary<Material, nombre> dic = new Dictionary<Material, nombre>();
    private void Awake()
    {
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

    // Update is called once per frame
    void Update()
    {
        
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
        dic.Add(skins[0], nombre.bird);
        dic.Add(skins[1], nombre.bull);
        dic.Add(skins[2], nombre.dragon);
        dic.Add(skins[3], nombre.hawk);
        dic.Add(skins[4], nombre.head);
        dic.Add(skins[5], nombre.man);
        dic.Add(skins[6], nombre.manS);
        dic.Add(skins[7], nombre.owl);
    }
   
}
public enum nombre
{
    bird,bull,dragon,hawk,head,man,manS,owl
}