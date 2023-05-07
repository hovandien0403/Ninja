using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    ItemCollector itemCollector;
    [SerializeField] GameObject player;
    [SerializeField] private Text totalPoints;

    private void Awake()
    {
        itemCollector = player.GetComponent<ItemCollector>();
    }


    public void showPoint()
    {
        gameObject.SetActive(true);
        int point = itemCollector.GetPoint();
        totalPoints.text = point.ToString() + " POINTS";
    }

    public void RestartButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
