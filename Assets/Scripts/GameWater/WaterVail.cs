using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVail : MonoBehaviour {

    public bool _active;
    public Sprite VailEmpty;
    public Sprite Water;
    public Sprite Blood1;
    public Sprite Blood2;
    public Sprite Blood3;
    public Sprite Eyes1;
    public Sprite Eyes2;
    public Sprite Eyes3;
    public Sprite Frog1;
    public Sprite Frog2;

    SpriteRenderer _vailBlood;
    SpriteRenderer _vailFrog;
    SpriteRenderer _vailEyes;

    SpriteRenderer _sprite;
    int _frogs;
    int _eyes;
    int _waterCC;
    GameWater _manager;

	// Use this for initialization
	void Start () {
        _manager = transform.parent.Find("GameWaterManager").GetComponent<GameWater>();
        _sprite = GetComponent<SpriteRenderer>();

        _vailBlood = transform.Find("Blood").GetComponent<SpriteRenderer>();
        _vailFrog = transform.Find("Frog").GetComponent<SpriteRenderer>();
        _vailEyes = transform.Find("Eyes").GetComponent<SpriteRenderer>();

        Init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        _active = true;
        _frogs = 0;
        _waterCC = 0;
        _eyes = 0;
        UpdateTexture();
    }
        
    void UpdateState()
    {
        while (true)
        {
            if (_waterCC < 20)
            {
                _waterCC = 0;
                break;
            }

            if (_waterCC < 30)
            {
                _waterCC = 20;
                break;
            }

            if (_waterCC < 50)
            {
                _waterCC = 30;
                break;
            }

            _waterCC = 50;
            break;
        }
                
        UpdateTexture();
    }

    void UpdateTexture()
    {
        if (_waterCC == 0)
        {
            _vailBlood.sprite = Water;
        }
        else if (_waterCC > 0 && _waterCC < 30)
        {
            _vailBlood.sprite = Blood1;
        }
        else if (_waterCC >= 30 && _waterCC < 40)
        {
            _vailBlood.sprite = Blood2;
        }
        else if (_waterCC >= 40)
        {
            _vailBlood.sprite = Blood3;
        }

        if (_frogs == 0)
        {
            _vailFrog.gameObject.SetActive(false);
        }
        else if (_frogs == 1)
        {
            _vailFrog.gameObject.SetActive(true);
            _vailFrog.sprite = Frog1;
        }
        else
        {
            _vailFrog.gameObject.SetActive(true);
            _vailFrog.sprite = Frog2;
        }

        if (_eyes == 0)
        {
            _vailEyes.gameObject.SetActive(false);
        }
        else if (_eyes == 1)
        {
            _vailEyes.gameObject.SetActive(true);
            _vailEyes.sprite = Eyes1;
        }
        else if (_eyes == 2)
        {
            _vailEyes.gameObject.SetActive(true);
            _vailEyes.sprite = Eyes2;
        }
        else
        {
            _vailEyes.gameObject.SetActive(true);
            _vailEyes.sprite = Eyes3;

        }
    }

    public bool IsSuccess()
    {
        return (_frogs == 1 && _eyes == 2 && _waterCC == 30);
    }

    public void Fill(int cc)
    {
        _waterCC += cc;
        UpdateState();
    }

    public void AddFrog()
    {
        _frogs++;
        UpdateState();
    }

    public void AddEye()
    {
        _eyes++;
        UpdateState();
    }
}
