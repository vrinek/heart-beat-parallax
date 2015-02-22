using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
//	public Camera myCamera;

	private Vector2 originalPosition;
	private float beatOffset;
	private int maxLayer = 9;
	private float maxLayerFloat = 9.0f;

	private Vector2 cameraOffsetPosition {
		get {
			return new Vector2(
				myCamera.transform.position.x - originalPosition.x,
				myCamera.transform.position.y - originalPosition.y
			);
		}
	}

	private Camera myCamera {
		get { return Camera.main; }
	}

	// Use this for initialization
	void Start () {
		// greater sortingLayerID is closer to the foreground
		int layerOffset = maxLayer - gameObject.renderer.sortingLayerID;
		beatOffset = layerOffset / maxLayerFloat;

		originalPosition = gameObject.transform.position;

		gameObject.transform.localScale *= (1.5f - layerOffset/maxLayerFloat);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(
			originalPosition.x + cameraOffsetPosition.x * beatOffset,
			originalPosition.y + cameraOffsetPosition.y * beatOffset,
			gameObject.transform.position.z
		);
	}
}
