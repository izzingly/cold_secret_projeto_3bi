using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightonoff : MonoBehaviour
{
    Light light;

	void Start ()
    {
		light = GetComponent<Light> ();
	}

	void Update ()
    {

		if (Input.GetKeyUp (KeyCode.F))
        {
            gameObject.GetComponent<AudioSource>().Play();
            light.enabled = !light.enabled;
		}
	}
}