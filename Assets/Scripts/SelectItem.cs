using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void SelectMe()
    {
        if ((this.tag == "RedFruit" && ItemsManager.Instance.CurrentItem == "YellowFruit") ||
            (this.tag == "YellowFruit" && ItemsManager.Instance.CurrentItem == "RedFruit"))
        {
            if (ItemsManager.Instance.IsItemExists("OrangeDye"))
                return;
            ItemsManager.Instance.AddItem(GlobalData.Instance.OrangeDye);
            ItemsManager.Instance.RemoveItem("RedFruit"); 
            ItemsManager.Instance.RemoveItem("YellowFruit");
            ItemsManager.Instance.UnselectAllItems();
            return;
        }

        if ((this.tag == "RedFruit" && ItemsManager.Instance.CurrentItem == "BlueFruit") ||
            (this.tag == "BlueFruit" && ItemsManager.Instance.CurrentItem == "RedFruit"))
        {
            if (ItemsManager.Instance.IsItemExists("PurpleDye"))
                return;
            ItemsManager.Instance.AddItem(GlobalData.Instance.PurpleDye);
            ItemsManager.Instance.RemoveItem("RedFruit");
            ItemsManager.Instance.RemoveItem("BlueFruit");
            ItemsManager.Instance.UnselectAllItems();
            return;
        }

        if ((this.tag == "BlueFruit" && ItemsManager.Instance.CurrentItem == "YellowFruit") ||
            (this.tag == "YellowFruit" && ItemsManager.Instance.CurrentItem == "BlueFruit"))
        {
            if (ItemsManager.Instance.IsItemExists("GreenDye"))
                return;
            ItemsManager.Instance.AddItem(GlobalData.Instance.GreenDye);
            ItemsManager.Instance.RemoveItem("BlueFruit");
            ItemsManager.Instance.RemoveItem("YellowFruit");
            ItemsManager.Instance.UnselectAllItems();
            return;
        }

        if (this.tag == ItemsManager.Instance.CurrentItem)
        {
            ItemsManager.Instance.UnselectAllItems();
            return;
        }

        Debug.Log(this.tag + " item selected");
        ItemsManager.Instance.UnselectAllItems();
        this.GetComponent<Image>().color = Color.red;
        ItemsManager.Instance.CurrentItem = this.tag;
    }
}
