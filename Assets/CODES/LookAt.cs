using UnityEngine;
using System.Collections;

 public class LookAt : MonoBehaviour
{
     public Transform target;
     
     void Update ()
    {
         transform.LookAt(target);
    }
 }
