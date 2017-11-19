using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameNonogramManager : MonoBehaviour {

    public GameObject Door;
    public GameObject HotSpot;

    bool[] _answer;
    bool[] _current;

	// Use this for initialization
	void Start () {
        _answer = new bool[]
        {
            false, true, false, true, false,
            true, true, true, true, true, 
            true, false, true, false, true,
            true, true, true, true, true, 
            false, true, true, true, false 
        };

        _current = new bool[25];
        for (int i = 0; i < 25; ++i)
        {
            _current[i] = false;
        }
		
	}
	
    public void SetSquare(string objName)
    {
        //remove "square" from the name
        string squareNum = objName.Remove(0, 6);
        Debug.Log(squareNum);
        int num = System.Convert.ToInt16(squareNum);
        num = (num / 10 - 1) * 5 + num - num / 10 * 10 - 1;
        Debug.Log(num.ToString());
        _current[num] = !_current[num];
        if (Validate())
            Success();
    }

    void Success()
    {
        Door.SetActive(false);
        HotSpot.SetActive(true);
        gameNomogram[] allObjs = GetComponentsInChildren<gameNomogram>();
        for (int i = 0; i < allObjs.Length; i++)
        {
            SpriteRenderer spr = allObjs[i].gameObject.GetComponent<SpriteRenderer>();
            if (spr.color == Color.black)
                spr.color = Color.green;
            allObjs[i]._active = false;
        }
    }

    bool Validate()
    {
        for (int i = 0; i < 25; ++i)
        {
            if (_current[i] != _answer[i])
            {
                return false;
            }
        }
        return true;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
