using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEyes : MonoBehaviour {

    public bool _active;
    GameWater _manager;
    Sprite _sprite;
    WaterVail _vail;

    const float TIME_TO_CHANGE_DIRECTION = 0.2f;

    bool _isMoving;
    float _timeToSwitch;
    // Use this for initialization
    void Start () {
        _manager = transform.parent.Find("GameWaterManager").GetComponent<GameWater>();
        _sprite = GetComponent<SpriteRenderer>().sprite;
        _vail = transform.parent.Find("Vail").GetComponent<WaterVail>();

        Init();
    }

    // Update is called once per frame
    void Update () {
        Move();
    }

    void OnMouseDown()
    {
        if (!_active)
            return;
        _vail.AddEye();
    }

    public void Init()
    {
        _active = true;
        _isMoving = true;
        _timeToSwitch = TIME_TO_CHANGE_DIRECTION;
    }

    void Move()
    {
        if (_isMoving)
        {
            _timeToSwitch -= Time.deltaTime;
            if (_timeToSwitch < 0)
            {
                _timeToSwitch = TIME_TO_CHANGE_DIRECTION;
                if(this.transform.rotation.z > 0)
                    this.transform.Rotate(0, 0, -10);
                else this.transform.Rotate(0, 0, 10);
            }
        }
    }

    public void StopMoving()
    {
        _isMoving = false;
        transform.Rotate(0, 0, 0);
    }
}
