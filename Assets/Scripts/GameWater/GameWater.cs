using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWater : MonoBehaviour {


    string _clickedObject;

    //public Sprite 

    WaterFrog _frog;
    WaterEyes _eyes;
    WaterVail _vail;
    WaterBanana _banana;

    public void DisableGame()
    {
        _frog._active = false;
        _frog.StopMoving();
        _eyes._active = false;
        _eyes.StopMoving();
        _vail._active = false;
        _banana._active = false;

    }
	// Use this for initialization
	void Start () {
        _frog = transform.parent.Find("Frog").GetComponent<WaterFrog>();
        _eyes = transform.parent.Find("Eye").GetComponent<WaterEyes>();
        _vail = transform.parent.Find("Vail").GetComponent<WaterVail>();
        _banana = transform.parent.Find("Banana").GetComponent<WaterBanana>();


        RestartScene();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartScene()
    {
        _clickedObject = "none";

        _banana.Init();
        _frog.Init();
        _vail.Init();

    }
        
    public string GetPreviewsObject()
    {
        Debug.Log(_clickedObject);
        return _clickedObject;
    }

}
