using UnityEngine;
using System.Collections;

public class throwChest : MonoBehaviour
{
    public GameObject ChestBroken;
    public GameObject HammerOnGround;
    public GameObject LockOnGround;
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
        if (ItemsManager.Instance.CurrentItem != "Chest")
            return;

        ItemsManager.Instance.RemoveItem("Chest");
        ChestBroken.SetActive(true);
        HammerOnGround.SetActive(true);
        LockOnGround.SetActive(true);
        StartCoroutine(SoundChestCrush());
    }

    IEnumerator SoundChestCrush()
    {
        yield return new WaitForSeconds(0.5F);
        GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.ChestCrushSound);
    }
}
