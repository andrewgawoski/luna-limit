using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleControllerScript : MonoBehaviour {

    public void StartPressed()
    {
        Debug.Log("Start button pressed");
        SceneManager.LoadScene("Game Scene");
    }

    public void SettingsPressed()
    {
        Debug.Log("Settings button pressed");
    }

    public void ScoresPressed()
    {
        Debug.Log("Scores button pressed");
    }

    public void QuitPressed()
    {
        Debug.Log("Quit button pressed");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
