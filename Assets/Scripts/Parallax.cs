using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	private Vector2 originalPosition;
	private int maxLayer = 9;
	private float maxScale = 1.5f;

	// How much the object is going to follow the camera.
	// Ranges from 0 when close to the foreground to 1 when far in the background.
	private float followRatio;

	private Vector2 cameraOffsetPosition {
		get {
			return new Vector2(
				Camera.main.transform.position.x - originalPosition.x,
				Camera.main.transform.position.y - originalPosition.y
			);
		}
	}

	void Start () {
		originalPosition = gameObject.transform.position;
		
		// Greater sortingLayerID is closer to the foreground, rendered last.
		int layerOffset = maxLayer - gameObject.renderer.sortingLayerID;
		followRatio = layerOffset / (float)maxLayer;

		// Resize the object to look closer or far away from the camera.
		gameObject.transform.localScale *= (maxScale - followRatio);
	}
	
	void Update () {
		gameObject.transform.position = new Vector3(
			originalPosition.x + cameraOffsetPosition.x * followRatio,
			originalPosition.y + cameraOffsetPosition.y * followRatio,
			gameObject.transform.position.z
		);
	}
}
