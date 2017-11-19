using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance = null;

    public string CurrentItem = "";

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(1)) // right mouse
        {
            UnselectAllItems();
        }
	}

    public void UnselectAllItems()
    {
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Transform item = this.transform.GetChild(i);
            item.GetComponent<Image>().color = Color.white;
        }
        CurrentItem = "";
    }

    public void AddItem(GameObject item)
    {
        GameObject itemInstance = Instantiate(item) as GameObject;
        itemInstance.transform.SetParent(this.transform, false);
    }

    public void RemoveItem(string tag)
    {
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Transform item = this.transform.GetChild(i);
            if (item.tag == tag)
            {
                Destroy(item.gameObject);
                CurrentItem = "";
                return;
            }
        }
    }

    public bool IsItemExists(string itemName)
    {
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Transform item = this.transform.GetChild(i);
            if (item.tag == itemName)
            {
                return true;
            }
        }
        return false;
    }
}
