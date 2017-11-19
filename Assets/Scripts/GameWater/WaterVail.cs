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

    WaterGlass _water20;
    WaterGlass _water50;
	// Use this for initialization
	void Start () {
        _manager = transform.parent.Find("GameWaterManager").GetComponent<GameWater>();
        _sprite = GetComponent<SpriteRenderer>();
        _water20 = transform.parent.Find("Glass20").GetComponent<WaterGlass>();
        _water50 = transform.parent.Find("Glass50").GetComponent<WaterGlass>();

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

    void OnMouseDown()
    {
        if (!_active)
            return;
        UpdateState();
        _manager.ObjectClicked("vail");
    }

    void UpdateState()
    {
        string previewsObj = _manager.GetPreviewsObject();
        int water = 0;
        if (previewsObj == "glass20")
        {
            water = _water20.GetWater();
            _water20.Empty();
        }
        if (previewsObj == "glass50")
        {
            water = _water50.GetWater();
            _water50.Empty();
        }
        if (previewsObj == "frog")
        {
            _frogs++;
        }
        if (previewsObj == "eyes")
        {
            _eyes++;
        }

        _waterCC += water;


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
        else
        {
            _vailEyes.gameObject.SetActive(true);
            _vailEyes.sprite = Eyes2;
        }
    }

    public bool IsSuccess()
    {
        return (_frogs == 1 && _eyes == 2 && _waterCC == 30);
    }
}
