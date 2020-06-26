using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private PlayerHealth player;
    public GameObject playerPrefab;
    public Transform startPos;

    private void Start()
    {
        InstPlayer();
    }


    private void InstPlayer()
    {        
        var playerP = Instantiate(playerPrefab, startPos);
        playerP.SetActive(true);
        player = playerP.GetComponent<PlayerHealth>();
        player.playerDie += InstPlayer;
    }

   
}
