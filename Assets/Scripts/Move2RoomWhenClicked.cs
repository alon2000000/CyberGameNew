using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2RoomWhenClicked : MonoBehaviour
{
    public string RoomName;
    public bool IsImmediate = false;
    public string ExceptionItem = "";

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        if (ItemsManager.Instance.CurrentItem != "" && ItemsManager.Instance.CurrentItem == ExceptionItem)
            return;

        if (!IsImmediate)
            CameraManager.Instance.MoveToRoom(RoomName);
        else
            CameraManager.Instance.MoveToRoomImmediately(RoomName);
    }
}
