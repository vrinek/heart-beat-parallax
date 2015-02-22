using UnityEngine;
using System.Collections;

public class ChangeOnBeat : MonoBehaviour {
	public Sprite[] states;
	public int beatDistance = 20; // frames

	private int counter;
	private int currentStateIndex = -1; // Will become 0 by AdvanceState() when this object is initialized.
	private int maxLayer = 9;

	void Start() {
		// Greater sortingLayerID is closer to the foreground, rendered last.
		int layerOffset = maxLayer - gameObject.renderer.sortingLayerID;
		counter = layerOffset * 5;

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
