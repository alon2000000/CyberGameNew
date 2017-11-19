using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBanana : MonoBehaviour {

    public bool _active;

    const float TIME_TO_EAT = 3f;

    public Sprite FullBanana;
    public Sprite EatenBanana;

    float _timeToEat;
    bool _isEaten;
    SpriteRenderer _sprite;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
	// Use this for initialization
	void Start () {
        
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_isEaten)
        {
            return;
        }
        this.transform.Rotate(0, 0, 1);
        _timeToEat -= Time.deltaTime;
        if (_timeToEat < 0)
        {
            _sprite.sprite = EatenBanana;
            _isEaten = false;
        }
	}

    void OnMouseDown()
    {
        if (!_active)
            return;
        Debug.Log("eat banana");
        _isEaten = true;
    }

    public void Init()
    {
        _active = true;
        _sprite.sprite = FullBanana;
        _timeToEat = TIME_TO_EAT;
        _isEaten = false;
    }
}
