using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public GameObject objectToMove;
	public Transform startPoints;
	public Transform endPoints;
	public float moveSpeed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		currentTarget = endPoints.position;
	}
	
	// Update is called once per frame
	void Update () {
		objectToMove.transform.position = Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
		if (objectToMove.transform.position == endPoints.position) {
			currentTarget = startPoints.position;
		}
		if (objectToMove.transform.position == startPoints.position) {
			currentTarget = endPoints.position;
		}
	}
}
