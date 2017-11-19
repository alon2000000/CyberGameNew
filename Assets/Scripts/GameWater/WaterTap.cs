using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour {

    public bool _active;
    const float TIME_TO_POUR = 1;

    public Sprite TAP_CLOSED;
    public Sprite TAP_OPEN;

    SpriteRenderer _sprite;
    GameWater _manager;
    WaterVail _vail;

    bool _isPourWater;
    float _timeToPour;
	// Use this for initialization
	void Start () {
        _sprite = GetComponent<SpriteRenderer>();
        _manager = transform.parent.Find("GameWaterManager").GetComponent<GameWater>();
        _vail = transform.parent.Find("Vail").GetComponent<WaterVail>();
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        if (_isPourWater)
        {
            _timeToPour -= Time.deltaTime;
        
            if (_timeToPour < 0)
            {
                _sprite.sprite = TAP_CLOSED;
                _isPourWater = false;
                _timeToPour = TIME_TO_POUR;
            }
        }
	}


    public void Init()
    {
        _active = true;
        _isPourWater = false;
        _timeToPour = TIME_TO_POUR;
        gameObject.SetActive(true);
        _sprite.sprite = TAP_CLOSED;
    }

    void OnMouseDown()
    {
        if (!_active)
            return;
        _isPourWater = true;
        _sprite.sprite = TAP_OPEN;
        _vail.Fill(30);

    }

    public void ObjectWasClicked(string newObject)
    {
    }
}
