using UnityEngine;
using System.Collections;

public class GeneratesPatries : MonoBehaviour {
	public int numberOfPastries = 1000;
	public GameObject pastryPrefab;

	private int minSortingLayerID = 1;
	private int maxSortingLayerID = 9;

	private float maxHorizontalOffset = 20;
	private float maxVerticalOffset = 10;

	// Use this for initialization
	void Start () {
		System.Random randomGen = new System.Random(7);

		for(int i = 0; i < numberOfPastries; i++) {
			int newSortingLayerID = randomGen.Next(minSortingLayerID, maxSortingLayerID + 1);
			float x = Random.Range(-maxHorizontalOffset, maxHorizontalOffset);
			float y = Random.Range(-maxVerticalOffset, maxVerticalOffset);

			GameObject newPastry = Instantiate(pastryPrefab) as GameObject;
			newPastry.renderer.sortingLayerID = newSortingLayerID;
			newPastry.transform.position = new Vector2(x, y);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
