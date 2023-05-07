using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherry = 0;
    [SerializeField] private Text cherryText;

    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherry++;
            cherryText.text = "Cherry: " + cherry;
        }
    }

    public int GetPoint()
    {
        return cherry;
    }

}
