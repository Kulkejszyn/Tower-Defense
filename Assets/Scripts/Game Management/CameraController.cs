using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Vector2 xPosClamp;
	public Vector2 zPosClamp;

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float smooth = 10f;
	public float scrollSpeed = 50f;

	public new Camera camera;

	float minY = 20f;
	float maxY = 70f;

	bool doMovement = true;

	[Header("Camera will lay on line between this points")]
	public Transform centerPoint;
	public Transform passPoint;
	public float distance = 50f;

	void Update() {
		if (GameManager.gameIsOver) {
			doMovement = false;
			return;
		}

		if (!doMovement)
			return;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		camera.orthographicSize -= scroll * scrollSpeed;

		// transform.position = Vector3.Lerp(transform.transform.position, pos, Time.deltaTime * smooth);

		// transform.position = new Vector3(
		// 	Mathf.Clamp(transform.position.x, xPosClamp.x, xPosClamp.y),
		// 	transform.position.y,
		// 	Mathf.Clamp(transform.position.z, zPosClamp.x, zPosClamp.y)
		// );
	}
}