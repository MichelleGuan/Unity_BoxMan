using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
        Transform parent = GameObject.Find("Canvas").transform;
        this.transform.SetParent(parent, true); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
