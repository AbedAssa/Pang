using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Represent menu panel.
public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Button continuButton;
    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Button restartGameButton;

    public static GameUIController instance;

    private void Awake()
    {
        instance = this;
    }
    //Set listeners for the buttons.
    void Start()
    {
        pauseButton.onClick.AddListener(UserClickPauseButton);
        continuButton.onClick.AddListener(UserClickedContinueButton);
        homeButton.onClick.AddListener(UserClcikHomeButton);
        restartGameButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    private void UserClickedContinueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UserClickPauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    private void UserClcikHomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    
    
}
