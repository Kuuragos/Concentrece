using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public nombre myType;

    public bool show = false;
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

        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));

        }
    }
    public void Hide()
    {
        show = false;
    }
}
