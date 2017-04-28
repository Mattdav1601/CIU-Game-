using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("function recieved call");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void artisticStatement()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }



}
