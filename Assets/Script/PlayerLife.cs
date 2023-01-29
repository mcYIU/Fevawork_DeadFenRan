using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    AudioSource AS;
    Rigidbody2D rb2d;
    PlayerController controller;

    public int totalLife = 1;
    public static int life;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    public void Kill()
    {
         controller.enabled = false;
         rb2d.velocity = new Vector2(0, rb2d.velocity.y);
         Invoke("Restart",5f);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        life = totalLife;
    }
}