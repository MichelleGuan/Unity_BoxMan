using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ApplicationManager : MonoBehaviour
{
    Transform window;
   
    void Start()
    {
        window = GameObject.Find("Window").transform;
        Debug.Log(window);
        Level("LevelPanel02", "LevelPanel01");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Level(string thislevel, string nextlevel)
    {
        Transform nextlevelt;
        if(GameObject.Find(nextlevel) == null)
        {
        nextlevelt = (Instantiate(Resources.Load(nextlevel)) as GameObject).transform;
        Destroy(GameObject.Find(thislevel));
        nextlevelt.gameObject.name = nextlevel;
        nextlevelt.SetParent(window);
        nextlevelt.localPosition = new Vector3(1f, -16f, 0f);
        nextlevelt.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
         nextlevelt = GameObject.Find(nextlevel).transform;
        }
        var btn = nextlevelt.Find("Button").GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => { Level(nextlevel,thislevel); });
    }

}
