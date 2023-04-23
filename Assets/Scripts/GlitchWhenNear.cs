using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;


public class GlitchWhenNear : MonoBehaviour
{
    public DigitalGlitch GlitchEffect;
    public AnalogGlitch GlitchEffect2;

    public float Intensity;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Vector3 distanceVector = collider.transform.position - transform.position; 
            GlitchEffect2.scanLineJitter = Intensity / distanceVector.magnitude;
           // GlitchEffect.intensity = Intensity / distanceVector.magnitude;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
          Vector3 distanceVector = collider.transform.position - transform.position; 

          //ß  GlitchEffect.intensity = 0f;
            GlitchEffect2.scanLineJitter = 0f;
    }
}