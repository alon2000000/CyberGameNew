using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullSend : MonoBehaviour {

    public bool _active;
    public Sprite SpriteLock;
    public Sprite SpriteUnlock;

    // Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = SpriteLock;
        _active = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (!_active)
            return;
        bool isOpen = transform.parent.GetComponent<BullCodePlate>().TryToOpenLock();
        if (isOpen)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteUnlock;
            DisableGame();
        }
    }

    void DisableGame()
    {
        _active = false;
        BullArrowPressed[] bap = transform.parent.Find("BullDigit1").GetComponentsInChildren<BullArrowPressed>();
        bap[0]._active = false;
        bap[1]._active = false;
        bap = transform.parent.Find("BullDigit2").GetComponentsInChildren<BullArrowPressed>();
        bap[0]._active = false;
        bap[1]._active = false;
        bap = transform.parent.Find("BullDigit3").GetComponentsInChildren<BullArrowPressed>();
        bap[0]._active = false;
        bap[1]._active = false;
        bap = transform.parent.Find("BullDigit4").GetComponentsInChildren<BullArrowPressed>();
        bap[0]._active = false;
        bap[1]._active = false;
    }
}
