using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLockClick : MonoBehaviour
{
    public GameObject dragonOpenMouth;
    public GameObject bellWithRopeConnected;
    public GameObject bellWithRopeOnEarth;
    public GameObject pullRope;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        if (ItemsManager.Instance.CurrentItem != "DragonKey")
            return;

        ItemsManager.Instance.RemoveItem("DragonKey");
        dragonOpenMouth.SetActive(true);
        bellWithRopeConnected.SetActive(false);
        bellWithRopeOnEarth.SetActive(true);
        pullRope.SetActive(true);
        GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.Key);
    }
}
