using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullArrowPressed : MonoBehaviour {
    public bool IsUp;
    public bool _active;
	// Use this for initialization
	void Start () {
        _active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (!_active)
            return;
        Debug.Log("clicked");
        ((Digit)transform.parent.GetComponentInChildren<Digit>()).ChangeDigit(IsUp);
    }
}
