using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEntry : MonoBehaviour {
    public Sprite Sprite0;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;
    public Sprite Sprite9;

    public Sprite Hit;
    public Sprite Close;
    public Sprite Miss;


	// Use this for initialization

    BullEntry(){
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init (int[] guess, int[] result) {
        transform.Find("Digit1").GetComponent<SpriteRenderer>().sprite = getDigitSprite(guess[0]);
        transform.Find("Digit2").GetComponent<SpriteRenderer>().sprite = getDigitSprite(guess[1]);
        transform.Find("Digit3").GetComponent<SpriteRenderer>().sprite = getDigitSprite(guess[2]);
        transform.Find("Digit4").GetComponent<SpriteRenderer>().sprite = getDigitSprite(guess[3]);

        string[] feedback = new string[4] { "Feedback1", "Feedback2", "Feedback3", "Feedback4" };
        int currentFeedback = 0;

        for (int i = 0; i < 4; i++)
        {
            if (result[i] == 2)
            {
                transform.Find(feedback[currentFeedback]).GetComponent<SpriteRenderer>().sprite = Hit;
                currentFeedback++;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (result[i] == 1)
            {
                transform.Find(feedback[currentFeedback]).GetComponent<SpriteRenderer>().sprite = Close;
                currentFeedback++;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (result[i] == 0)
            {
                Destroy(transform.Find(feedback[currentFeedback]).gameObject);
                currentFeedback++;
            }
        }

    }

    Sprite getDigitSprite(int digit)
    {
        switch (digit)
        {
            case 0:
                return Sprite0;
            case 1:
                return Sprite1;
            case 2:
                return Sprite2;
            case 3:
                return Sprite3;
            case 4:
                return Sprite4;
            case 5:
                return Sprite5;
            case 6:
                return Sprite6;
            case 7:
                return Sprite7;
            case 8:
                return Sprite8;
            case 9:
                return Sprite9;
            default:
                return Sprite0;
        }
    }
}
