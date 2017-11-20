using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        Physics2D.queriesHitTriggers = true; //needed so the objects will get notification where the mouse clicks on them
    }

	void Start ()
    {
        Debug.Log("Startttttt");
        GlobalData.Instance.GetComponent<AudioSource>().clip = GlobalData.Instance.BkgrMenu;
        GlobalData.Instance.GetComponent<AudioSource>().Play();
    }

    void Update ()
    {
 
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToScene(string sceneName)
    {
        GlobalData.Instance.GetComponent<AudioSource>().clip = GlobalData.Instance.BkgrGame;
        GlobalData.Instance.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(sceneName);
    }
}
