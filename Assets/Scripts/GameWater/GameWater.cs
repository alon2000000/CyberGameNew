using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWater : MonoBehaviour {


    string _clickedObject;

    //public Sprite 

    WaterFrog _frog;
    WaterEyes _eyes;
    WaterVail _vail;
    WaterGlass _glass20;
    WaterGlass _glass50;
    WaterBanana _banana;

    bool _is20GlassFull;
    bool _is50GlassFull;

    public void DisableGame()
    {
        _frog._active = false;
        _eyes._active = false;
        _vail._active = false;
        _glass20._active = false;
        _glass50._active = false;
        _banana._active = false;

    }
	// Use this for initialization
	void Start () {
        _frog = transform.parent.Find("Frog").GetComponent<WaterFrog>();
        _eyes = transform.parent.Find("Eye").GetComponent<WaterEyes>();
        _vail = transform.parent.Find("Vail").GetComponent<WaterVail>();
        _glass20 = transform.parent.Find("Glass20").GetComponent<WaterGlass>();
        _glass50 = transform.parent.Find("Glass50").GetComponent<WaterGlass>();
        _banana = transform.parent.Find("Banana").GetComponent<WaterBanana>();

        _glass20.SetOtherGlass(ref _glass50);
        _glass50.SetOtherGlass(ref _glass20);

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
        _glass20.Init();
        _glass50.Init();

    }

    public void ObjectClicked(string objectName)
    {        
        _clickedObject = objectName;
        if (objectName != "frog")
            _frog.ObjectWasClicked(objectName);
        if (objectName != "eyes")
            _eyes.ObjectWasClicked(objectName);
//        _vail.ObjectWasClicked(objectName);
        if (objectName != "glass20")
            _glass20.ObjectWasClicked(objectName);
        if (objectName != "glass50")
            _glass50.ObjectWasClicked(objectName);

    }

    public string GetPreviewsObject()
    {
        Debug.Log(_clickedObject);
        return _clickedObject;
    }

}
