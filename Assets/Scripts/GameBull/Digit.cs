using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Digit : MonoBehaviour {

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

    private SpriteRenderer _sprite;
    private int _currentDigit;

	// Use this for initialization
	void Start () {
        _sprite = GetComponent<SpriteRenderer>();
        _currentDigit = 0;
        setTexture(_currentDigit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDigit(bool isUp)
    {
        if (isUp)
        {
            _currentDigit += 1;
        }
        else
        {
            _currentDigit -= 1;
        }
        if (_currentDigit == 6)//if (_currentDigit == 10)
        {
            _currentDigit = 0;
        }
        if (_currentDigit == -1)
        {
            _currentDigit = 5;//_currentDigit = 9;
        }
        setTexture(_currentDigit);
    }

    void setTexture(int digitNumber)
    {
        Debug.Log("ChangeDigit");
        switch (digitNumber)
        {
            case 0:
                _sprite.sprite = Sprite0;
                break;
            case 1:
                _sprite.sprite = Sprite1;
                break;
            case 2:
                _sprite.sprite = Sprite2;
                break;
            case 3:
                _sprite.sprite = Sprite3;
                break;
            case 4:
                _sprite.sprite = Sprite4;
                break;
            case 5:
                _sprite.sprite = Sprite5;
                break;
            case 6:
                _sprite.sprite = Sprite6;
                break;
            case 7:
                _sprite.sprite = Sprite7;
                break;
            case 8:
                _sprite.sprite = Sprite8;
                break;
            case 9:
                _sprite.sprite = Sprite9;
                break;
        }
    }

    public int GetDigit()
    {
        return _currentDigit;
    }
}
