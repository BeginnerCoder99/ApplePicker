using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject startScreenPanel;

    void Start()
    {
        Time.timeScale = 0f;
        //startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        startScreenPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

