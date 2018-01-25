using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yellow : MonoBehaviour {
GameObject[] box;
	// Use this for initialization
	void Start () {
        box = GameObject.FindGameObjectsWithTag("box");
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool hasYellow = false;
       
        foreach (GameObject d in box)
        { if (d != null) { 
            if (d.transform.position.x > this.transform.position.x - 2 && this.transform.position.y + 2 > d.transform.position.y && this.transform.position.y - 2 < d.transform.position.y && d.transform.position.x < this.transform.position.x + 2)
            {
                hasYellow = true;
                break;
            }
        }
}
        if (hasYellow)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            GetComponent<Image>().color = new Color(255F,255F,255F,0.25F);
        }
	}
}
