using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullCodePlate : MonoBehaviour {

    public GameObject Door;
    public GameObject HotSpot;

    const int MAX_TRIES = 10;

    int[] _digits = new int[4];
    private BullResultsManager _bullResultScript;

    int _tries;

	// Use this for initialization
	void Start () {
        RestartGame();
        _bullResultScript = transform.parent.Find("BullResult").GetComponent<BullResultsManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool TryToOpenLock()
    {
        int[] digits = new int[4];
        int[] success = new int[4]{0,0,0,0}; //0 -none; 1-close; 2-bull
        int[] relevant = new int[4]{0,0,0,0}; //0 -none; 1-used
      
        for(int i=0;i<4;i++)
        {
            digits[i] = transform.GetChild(i).GetComponentInChildren<Digit>().GetDigit();
            if (digits[i] == _digits[i])
            {
                success[i] = 2;
                relevant[i] = 1;
            }
        }

        for(int i=0;i<4;i++)
        {
            if (digits[i] != _digits[i])
            {
                for(int j= 0; j<4; j++)
                {
                    if(digits[i] == _digits[j])
                    {
                        if(relevant[j] == 0)
                        {
                            success[i] = 1;
                            relevant[j] = 1;
                            break;
                        }
                    }
                }
   
            }
        }

        for(int i=0; i<4; i++)
        {
            if(success[i] != 2)
            {
                WrongGuess(digits, success);
                return false;
            }
        }

        Solved();
        return true;
    }

    private void Solved()
    {
        HotSpot.SetActive(true);
        Door.SetActive(false);
        GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.DoorSound);
    }

    private void WrongGuess(int[] guess, int[] guessResult)
    {
        _tries++;
        _bullResultScript.AddEntry(guess, guessResult);
        if (_tries == MAX_TRIES)
        {
            RestartGame();
            _bullResultScript.RestartResultsBoard();
        }
    }

    private void RestartGame()
    {
        _tries = 0;

        _digits[0] = Random.Range(0,6);//_digits[0] = Random.Range(0,10);
        _digits[1] = Random.Range(0,6);//_digits[1] = Random.Range(0,10);
        _digits[2] = Random.Range(0,6);//_digits[2] = Random.Range(0,10);
        _digits[3] = Random.Range(0,6);//_digits[3] = Random.Range(0,10);
    }
}
