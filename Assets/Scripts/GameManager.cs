using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] players;

    private void Start()
    {

        players = GameObject.FindGameObjectsWithTag(PlayerController.PLAYER_TAG);
        InvokeRepeating(nameof(CheckWinWstate), 2, 2);
    }

    public void CheckWinWstate()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount < players.Length)
        {
            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(0);
    }
}
