using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instan : MonoBehaviour
{

    public GameObject Ob = null;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(Ob);
    }
}
