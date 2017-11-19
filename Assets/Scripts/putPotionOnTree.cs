using UnityEngine;
using System.Collections;

public class putPotionOnTree : MonoBehaviour
{
    public GameObject FruitsOnTree;
    public GameObject RedFruitOnGround;
    public GameObject RedFruitOnGround2;
    public GameObject BlueFruitOnGround;
    public GameObject BlueFruitOnGround2;
    public GameObject YellowFruitOnGround;
    public GameObject YellowFruitOnGround2;

    private bool _isFruitsOnTree = false;
    private bool _isFruitsOnGround = false;
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
        if (ItemsManager.Instance.CurrentItem == "Potion")
        {
            ItemsManager.Instance.RemoveItem("Potion");
            _isFruitsOnTree = true;
            FruitsOnTree.SetActive(true);
            GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.Bloom);
        }

        if (ItemsManager.Instance.CurrentItem == "Hammer" && !_isFruitsOnGround && _isFruitsOnTree)
        {
            _isFruitsOnGround = true;
            ItemsManager.Instance.UnselectAllItems();
            RedFruitOnGround.SetActive(true);
            RedFruitOnGround2.SetActive(true);
            BlueFruitOnGround.SetActive(true);
            BlueFruitOnGround2.SetActive(true);
            YellowFruitOnGround.SetActive(true);
            YellowFruitOnGround2.SetActive(true);
            GlobalData.Instance.GetComponent<AudioSource>().PlayOneShot(GlobalData.Instance.HitTreeSound);
        }
    }
}
