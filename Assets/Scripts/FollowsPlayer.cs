using UnityEngine;
using System.Collections;

public class FollowsPlayer : MonoBehaviour {
	private GameObject myPlayer;

	// Use this for initialization
	void Start () {
		myPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(
			myPlayer.transform.position.x,
			myPlayer.transform.position.y,
			gameObject.transform.position.z
		);
	}
}
