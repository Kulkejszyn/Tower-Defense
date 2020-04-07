using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour {
	public Camera uiCamera;
	public Camera parentCamera;
	private void Update() {
		uiCamera.orthographicSize = parentCamera.orthographicSize;
	}
}