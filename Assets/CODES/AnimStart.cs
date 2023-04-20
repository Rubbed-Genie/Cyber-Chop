using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;

public class AnimStart : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.Play("Rube");
        }
        
        if (Input.GetKeyDown("2"))
        {
            anim.Play("Rube3");
        }
    }
    
}
