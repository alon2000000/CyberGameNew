using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWhenClicked : MonoBehaviour
{
    public GameObject ItemToAddObj;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {

        Destroy(this.gameObject);
        ItemsManager.Instance.AddItem(ItemToAddObj);
        GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.PickupSound);
    }
}
