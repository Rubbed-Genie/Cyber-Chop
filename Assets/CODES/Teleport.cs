using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject Destination;

    private void OnTriggerEnter(Collider other)
    {

        other.transform.position = Destination.transform.position;



    }
}