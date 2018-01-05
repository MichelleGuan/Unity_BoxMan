using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
        Application.Quit();
	}
    public void Level2()
    {
        SceneManager.LoadScene(1);
    }
    public void Level1()
    {
        SceneManager.LoadScene(0);
    }
}
