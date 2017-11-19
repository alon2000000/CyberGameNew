using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData Instance = null;

    public GameObject OrangeDye;
    public GameObject GreenDye;
    public GameObject PurpleDye;

    public AudioClip PickupSound;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // doors
    public bool IsDoorOpen_Start2Outside = false;
    public bool IsDoorOpen_Start2Ladder = false;
    public bool IsDoorOpen_Start2Stairs = false;

    // items
    public bool IsRopeTaken = false;
    public bool IsRopeOnLadder = false;


    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
