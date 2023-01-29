using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boatman : MonoBehaviour {

	public AudioClip Sound;
	public Canvas canvas;
	public GameObject gameOver;
	public string sceneName;

	Animator anim;
	AudioSource AS;

	void Start()
	{
		anim = GetComponent<Animator>();
		AS = GetComponent<AudioSource>();
	}


	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			anim.SetBool("player",true);
			AS.Play();
			canvas.enabled = false;
			Invoke("GameOver", 1);
		}
	}

	void GameOver()
    {
		gameOver.SetActive(true);
		Invoke("StartLoadScene", 10);
	}

	void StartLoadScene()
	{
		SceneManager.LoadScene(sceneName);
	}
}

