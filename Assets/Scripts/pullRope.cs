using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullRope : MonoBehaviour
{
    public GameObject bellMark1;
    public GameObject bellMark2;
    public GameObject bellWithRopeOnEarth;
    public GameObject bellWithoutRope;
    public GameObject ropeOnGround;
    private int _counter = 0;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        _counter++;

        if (_counter == 1)
        {
            bellMark1.SetActive(true);
        }
        if (_counter == 2)
        {
            bellMark2.SetActive(true);
            bellWithRopeOnEarth.SetActive(false);
            bellWithoutRope.SetActive(true);
            ropeOnGround.SetActive(true);
        }
    }
}
