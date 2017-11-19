using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private bool _isOn;
    public bool IsOn
    {
        get { return _isOn; }
        set
        {
            _isOn = value;
            updateScreenColor();
        }
    }

    void Start ()
    {
        IsOn = true;
	}
	
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        Debug.Log("clicked Computer ");
        IsOn = !IsOn;
    }

    private void updateScreenColor()
    {
        if (_isOn)
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
        else
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
    }
}
