using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectingRopeToLadder : MonoBehaviour
{
    public GameObject ToDownRoom;
    public GameObject RopeOnLadder;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        if (ItemsManager.Instance.CurrentItem != "Rope")
            return;
        ItemsManager.Instance.RemoveItem("Rope");
        RopeOnLadder.SetActive(true);
        ToDownRoom.SetActive(true);
        Destroy(this.gameObject);
    }
}
