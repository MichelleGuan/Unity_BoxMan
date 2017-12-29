using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
    public void Restart()
    {
        EditorSceneManager.LoadScene("myboxman01");
    }
}
