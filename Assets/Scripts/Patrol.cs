using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

    public Transform[] patrolPoints;
    public float moveSpeed;

    private int currentPoint;

	void Start () {
        GetComponent<Transform>().position = patrolPoints[0].position;
        currentPoint = 0;
	}

	void Update () {
        PatrolBetweenPoints();
	}

    void PatrolBetweenPoints()
    {
        if (GetComponent<Transform>().position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
            if (patrolPoints.Length <= currentPoint)
            {
                currentPoint = 0;
            }
        }

        GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }
}
