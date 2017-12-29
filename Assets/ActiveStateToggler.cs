using UnityEngine;
using System.Collections;

public class ActiveStateToggler : MonoBehaviour
{
    public GameObject target;
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf == true)
        {
            target.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}