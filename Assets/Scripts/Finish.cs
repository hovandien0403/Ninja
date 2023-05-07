using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    Rigidbody2D rb;
    ItemCollector itemCollector;
    CameraShake cameraShake;
    [SerializeField] GameObject cam;

    [SerializeField] GameObject completeText;
    [SerializeField] GameObject player;
    GameObject[] cherry;

    [SerializeField] private Text missCherryText;
    [SerializeField] private AudioSource missSound;
    [SerializeField] private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Awake()
    {
        cameraShake = cam.GetComponent<CameraShake>();
    }
    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        cherry = GameObject.FindGameObjectsWithTag("Cherry");
        missCherryText.GetComponent<Text>();
        itemCollector = player.GetComponent<ItemCollector>();
        /* int missCherry = totalCherry - point;*/

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {

            int totalCherry = cherry.Length;
            int point = itemCollector.GetPoint();


            if (totalCherry == point) {
                finishSound.Play();
                levelCompleted = true;
                rb.bodyType = RigidbodyType2D.Static;
                completeText.SetActive(true);
                Invoke("CompleteLevel", 2f);
            }
            else
            {
                int missCherry = totalCherry - point;
                cameraShake.ShakeCamera();
                missCherryText.text = "You are missing " + missCherry.ToString() + " cherry";
                missCherryText.enabled = true;
                missSound.Play();
                Invoke("hideMissCherry", 5f);
            }

        }
    }

    private void hideMissCherry() {
        missCherryText.enabled = false;
    }

    private bool checkCherry(int totalCherry, int point)
    {

        if (totalCherry == point)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
