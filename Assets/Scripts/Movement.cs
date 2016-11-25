using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public GameManager manager;

	public float moveSpeed;
    public GameObject deathParticles;

    private float maxSpeed = 20f;

	private Vector3 input;
    private Vector3 spawn;
    
	void Start () {
        spawn = GetComponent<Transform>().position;
        manager = manager.GetComponent<GameManager>();
	}
	
	void FixedUpdate () {
        PlayerSpeed();
	}

    void PlayerSpeed()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (GetComponent<Rigidbody>().velocity.magnitude <= maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        if (other.transform.tag == "Goal")
        {
            manager.WinScreen();
        }
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        GetComponent<Transform>().position = spawn;
    }
}
