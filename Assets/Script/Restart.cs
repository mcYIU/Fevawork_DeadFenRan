using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	PlayerLife player;

	void Awake () {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerLife>(); 
	}

	void Update () {
		if (Input.touchCount > 2 || Input.GetKeyDown (KeyCode.R)) {
			player.Reset();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
