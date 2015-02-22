using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	private float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(
			gameObject.transform.position.x + Input.GetAxis("Horizontal") * movementSpeed,
			gameObject.transform.position.y + Input.GetAxis("Vertical") * movementSpeed,
			gameObject.transform.position.z
		);
	}
}
