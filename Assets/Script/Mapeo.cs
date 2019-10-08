using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeo : MonoBehaviour
{
    public List<Material>myList = new List<Material>(16);
    public GameObject fichas;
    public  Material temp;

    void Start()
    {
        Shuffle(myList);
        for (int i = 0; i < 16; i++)
        {
            foreach (var item in myList)
            {
                int index=0;
                temp = myList[index];
                index++;
            }
            fichas.transform.GetChild(i).GetChild(0).GetComponent<MeshCollider>().material = temp;
            myList.Remove(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle(List<Material> list)
    {
        int n = list.Count;
        while(n>1)
        {
            int k = Random.Range(0, n + 1);
            Material valu = list[k];
            list[k] = list[n];
            list[n] = valu;

        }
    }
}
