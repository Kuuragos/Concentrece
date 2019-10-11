using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public nombre myType;
    GameObject[] tempo = new GameObject[2];
    public bool show = false;
    private void Start()
    {
        tempo[0] = null;
        tempo[1] = null;

    }
    private void OnMouseDown()
    {
        show = true;
            Invoke("Hide",2);
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));

            if (Input.GetMouseButtonDown(0))
            {
                Comparar();
            }
        }

    }
    public void Hide()
    {
        show = false;
    }
    void Comparar()
    {
        if (tempo[0] == null)
        {
            Debug.Log("combio temp1");
            tempo[0] = gameObject;
        }
        else 
        {
            Debug.Log("combio temp2");

            tempo[1] = gameObject;
            Eliminar();
        }
    }
    void Eliminar()
    {
        if (tempo[0] == tempo[1])
        {
            Destroy(tempo[0]);
            Destroy(tempo[1]);

        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));
            tempo[0] = null;
            tempo[1] = null;

        }
    }
}
