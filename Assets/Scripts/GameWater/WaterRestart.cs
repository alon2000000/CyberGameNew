using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRestart : MonoBehaviour {

    public GameObject Potion;
    public bool _active;
    WaterVail _vail;
	// Use this for initialization
	void Start () {
        _active = true;
        _vail = transform.parent.Find("Vail").GetComponent<WaterVail>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (!_active)
            return;
        if (_vail.IsSuccess())
        {
            Debug.Log("SUCCESS");
            _active = false;
            transform.parent.Find("GameWaterManager").GetComponent<GameWater>().DisableGame();
            ItemsManager.Instance.AddItem(Potion);
        }
        else
        {
            transform.parent.Find("GameWaterManager").GetComponent<GameWater>().RestartScene();    
        }
    }
}
