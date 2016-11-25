using UnityEngine;
using System.Collections;

public class ShowWinScreen : MonoBehaviour {
    [SerializeField]
    private GameObject winScreen;
    public GameManager manager;

    void Start()
    {
        winScreen.SetActive(false);
        manager = manager.GetComponent<GameManager>();
    }

    void Update()
    {
        SetObjectActive();
    }

    void SetObjectActive()
    {
        if (manager.completed == true)
        {
            winScreen.SetActive(true);
        }
    }
}
