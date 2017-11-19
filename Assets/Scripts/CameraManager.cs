using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public GameObject Target = null;
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;


    public static CameraManager Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);
    }

    // ================================================================================================ //
    void Start()
    {

    }
    // ================================================================================================ //
    void LateUpdate()
    {
        if (Target == null)
            return;

        Vector3 posNoZ = transform.position;
        posNoZ.z = Target.transform.position.z;

        Vector3 targetDirection = (Target.transform.position - posNoZ);

        interpVelocity = targetDirection.magnitude * 5f;

        Vector3 targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

        if (transform.position == targetPos + offset)
        {
            Target = null;
            /*Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;*/
            return;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos + offset, 1.0F/*0.25f*/);
    }
    // ================================================================================================ //
    public void MoveToRoom(string roomName)
    {
        Target = GameObject.Find(roomName);
        if (Target == null)
        {
            Debug.LogError("No such room: " + roomName);
        }
        /*else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }*/
    }
    // ================================================================================================ //
    public void MoveToRoomImmediately(string roomName)
    {
        Target = GameObject.Find(roomName);
        if (Target == null)
        {
            Debug.LogError("No such room: " + roomName);
        }

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);

        Target = null;
    }
    // ================================================================================================ //
}