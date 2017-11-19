using UnityEngine;
using System.Collections;

public class paintBell : MonoBehaviour
{
    public GameObject ExitDoor;
    public GameObject GreenBell1;
    public GameObject GreenBell2;
    public GameObject GreenBell3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (ItemsManager.Instance.CurrentItem != "GreenDye")
            return;

        ItemsManager.Instance.RemoveItem("GreenDye");
        GreenBell3.SetActive(true);
        StartCoroutine(OpenExitDoor());
    }

    IEnumerator OpenExitDoor()
    {
        yield return new WaitForSeconds(1.0F);
        ExitDoor.SetActive(false);
        GreenBell1.SetActive(false);
        GreenBell2.SetActive(false);
        GreenBell3.SetActive(false);
    }
}
