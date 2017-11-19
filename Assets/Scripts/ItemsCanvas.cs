using UnityEngine;
using System.Collections;

public class ItemsCanvas : MonoBehaviour
{
    public static ItemsCanvas Instance = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
