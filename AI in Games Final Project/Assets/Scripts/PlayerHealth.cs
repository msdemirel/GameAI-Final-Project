using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public Image[] hearts;
    public GameObject gameOverMenu;
   
    public void HealthCount()
    {
        playerHealth = playerHealth - 1;
        Debug.Log("trigger entered");
        UpdateHeartUI();
        if (playerHealth <= 0)
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        Cursor.visible = true;
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                // Heart should be visible as the player has health remaining
                hearts[i].enabled = true;
            }
            else
            {
                // Heart should be hidden as the player has lost this health point
                hearts[i].enabled = false;
            }
        }
    }


}
