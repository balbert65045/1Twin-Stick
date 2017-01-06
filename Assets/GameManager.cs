using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool recording = false; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
	}
}
