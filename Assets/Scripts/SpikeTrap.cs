using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {
    public float delayTime;
    
	void Start () {
        StartCoroutine(Go());
	}
	
    IEnumerator Go()
    {
        while(true)
        {
            GetComponent<Animation>().Play ();
            yield return new WaitForSeconds(delayTime);
        }
    }
}
