using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullResultsManager : MonoBehaviour {

    const float Y_POS_INTERVAL = 0.3f;
    float _nextYPos;

    public GameObject BullEntry;
	// Use this for initialization
	void Start () {
        _nextYPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEntry(int[] guess, int[] result)
    {
        GameObject bullEntry = Instantiate(BullEntry,this.transform);
        bullEntry.transform.position = new Vector3(bullEntry.transform.position.x, _nextYPos, bullEntry.transform.position.z);
        _nextYPos -= Y_POS_INTERVAL;
        bullEntry.GetComponent<BullEntry>().Init(guess, result);
    }

    public void RestartResultsBoard()
    {
        _nextYPos = transform.position.y;

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
