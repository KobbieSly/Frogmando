using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject gameOverPanel;
    public GameObject gamePlayPanel;
    public GameObject LevelCompletePanel;
    public GameObject StartingLily;
   
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    

    public void StartGame()
    {
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        LevelCompletePanel.SetActive(false);
        Player.transform.position = StartingLily.transform.position;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
    }

    public void GameComplete()
    {
        var win = Damage.FindObjectOfType<Damage>().CompleteLevelSound;
        Damage.FindObjectOfType<Damage>().frogSounds.PlayOneShot(win);
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        LevelCompletePanel.SetActive(true);

    }
}
