using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour {

	public List<GameObject> tiles;

	void Start() {
		foreach (Node tile in (Node[]) GameObject.FindObjectsOfType(typeof(Node))) {
			Instantiate(tiles[Random.Range(0, tiles.Count)], tile.transform.position, Quaternion.identity, tile.transform.parent);
			Destroy(tile.gameObject);
		}
	}
}