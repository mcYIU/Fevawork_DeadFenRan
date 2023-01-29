using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Player;
	public float xOffset;
	public float yOffset;
	[Range(0,1)]
	public float smoothTime;
	private Vector3 cameraPos;
	private Vector3 velocity = Vector3.zero;


	void Update () {

		cameraPos = new Vector3 (Player.position.x + xOffset, Player.position.y + yOffset, -10f);
		transform.position = Vector3.SmoothDamp(
			gameObject.transform.position, cameraPos, ref velocity, smoothTime);

	}

}
