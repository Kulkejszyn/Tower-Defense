using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {
	private static LevelInfo _instance;
	public static LevelInfo Instance{ get => _instance; }

	private void OnEnable() {
		_instance = this;	
	}
	
	public Transform spawnPoint;
	public Transform endPoint;

}