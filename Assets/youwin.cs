using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youwin : MonoBehaviour
{
    public GameObject target;
    GameObject[] box;
    List<int> list = new List<int>();
    // Use this for initialization
    void Start()
    {
        box = GameObject.FindGameObjectsWithTag("box");
    }
    void Update()
    {
            foreach (GameObject d in box)
            {
                if (d.transform.position.x > this.transform.position.x - 5 && this.transform.position.y + 5 > d.transform.position.y && this.transform.position.y - 3 < d.transform.position.y && d.transform.position.x < this.transform.position.x + 3)
                {
                    list.Add(1);                 
                }
            }
            if (list.Count == 4)
            {
                target.transform.localScale = new Vector3(1, 1, 1);
            }
    }
}
	
	