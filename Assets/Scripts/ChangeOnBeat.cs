using UnityEngine;
using System.Collections;

public class ChangeOnBeat : MonoBehaviour {
	public Sprite[] states;
	public int beatDistance = 20; // frames

	private int counter;
	private int currentStateIndex = -1; // will become 0 when initialized
	private int beatOffset;
	private int maxLayer = 9;

	void Start() {
		// greater sortingLayerID is closer to the foreground
		int layerOffset = maxLayer - gameObject.renderer.sortingLayerID;
		beatOffset = layerOffset * 5;

		counter = beatOffset;
		AdvanceState();
	}

	void Update () {
		counter++;

		if(counter == beatDistance) {
			counter = 0;
			AdvanceState();
		}
	}

	void AdvanceState() {
		(gameObject.renderer as SpriteRenderer).sprite = NextStateSprite();
	}

	Sprite NextStateSprite() {
		currentStateIndex++;
		if(currentStateIndex >= states.Length) { currentStateIndex = 0; }
		return states[currentStateIndex];
	}
}
