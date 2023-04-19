using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shlow: MonoBehaviour
{
    
    void Start()
	{
	Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.2f;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}