using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameNomogram : MonoBehaviour {

    bool _isBlack;
    SpriteRenderer _sprite;
    gameNonogramManager _manager;
    public bool _active;
    // Use this for initialization
	void Start () {
        _isBlack = false;
        _sprite = GetComponent<SpriteRenderer>();

        _manager = transform.GetComponentInParent<gameNonogramManager>();
        _active = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (!_active)
            return;
        _isBlack = !_isBlack;
        if(_isBlack)
            _sprite.color = Color.black;
        else _sprite.color = Color.white;

        _manager.SetSquare(gameObject.name);
    }
}
