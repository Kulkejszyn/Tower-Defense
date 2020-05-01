using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProceduralGenerator;
using UnityEngine;

public class Dummy : MonoBehaviour {
	[SerializeField] MapSize mapSize;
	[SerializeField] MapLength mapLength;
	[SerializeField] Vector3 buildPos = Vector3.zero;
	[SerializeField] GameObject parent;

	[Header("Tiles")]

	[SerializeField] GameObject baseTile;
	[SerializeField] GameObject cornerTile;
	[SerializeField] GameObject pathTile;

	private GameObject[, ] tiles;

	private void Start() {

		// if (this.baseTile == null && this.pathTile)
		// 	return;

		// if (tiles != null)
		// 	foreach (var tile in tiles)
		// 		if (tile != null)
		// 			UnityEditor.EditorApplication.delayCall += () => StartCoroutine(destroyObject(tile));

		MapGenerator mapGenerator = new MapGenerator(Random.Range(0, 99999999));
		mapGenerator.GenerateMap(mapSize, mapLength, false, 0.0f, 0.3f);

		char[, ] result = mapGenerator.Display();

		int dim = (int) result.GetLength(0);
		tiles = new GameObject[dim, dim];

		for (int x = 0; x < dim; x++)
			for (int y = 0; y < dim; y++) {
				GameObject toInstantiate;
				Quaternion quaternion = Quaternion.identity;

				switch (mapGenerator.GetTile(x, y)) {

					case TileType.EmptySpace:
						toInstantiate = baseTile;
						break;

					case TileType.Decor:
						toInstantiate = baseTile;
						break;
					case TileType.Decor2:
						toInstantiate = baseTile;
						break;

					case TileType.ElbowLeftDown:
					case TileType.ElbowLeftUp:
					case TileType.ElbowRightDown:
					case TileType.ElbowRightUp:
						toInstantiate = cornerTile;
						break;
					case TileType.HorizPath:
						toInstantiate = pathTile;
						break;
					case TileType.VertPath:
						quaternion = Quaternion.Euler(0, 90, 0);
						toInstantiate = pathTile;
						break;
					default:
						toInstantiate = baseTile;
						break;
				}

				GameObject tile = (GameObject) Instantiate(toInstantiate, buildPos + new Vector3(-x * 4, 0, y * 4), quaternion, parent.transform);
				tiles[x, y] = tile;
			}

	}

	IEnumerator destroyObject(GameObject obj) {
		yield return new WaitForSeconds(0.1f);
		DestroyImmediate(obj);
	}

}