using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    CameraShake cameraShake;
    [SerializeField] GameObject cam;

    public GameOverScreen gameOverScreen;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
        cameraShake = cam.GetComponent<CameraShake>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        cameraShake.ShakeCamera();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        gameOverScreen.showPoint();

    }

    /*private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }*/
}
