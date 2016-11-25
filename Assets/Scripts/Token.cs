using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour {

    public GameObject goal;

	void Start () {
        goal.SetActive(false);
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            goal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
