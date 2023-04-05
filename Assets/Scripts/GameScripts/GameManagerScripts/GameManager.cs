using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int fruitCount = 0;

    public TextMeshProUGUI fruitScore;

    public Button restartButton;

    public GameObject playerPrefab;

    private Vector3 playerLocation = new Vector3(-4f, -1.2f, 0);

    public GameObject applePrefab;

    public GameObject foreground;
    private Vector3[] appleLocs =
    {
        new Vector3(0.8f, -0.5f, 0),
        new Vector3(2.7f, -1.4f, 0),
        new Vector3(1, -3.5f, 0),
        new Vector3(1.7f, -3.5f, 0),
        new Vector3(1f, -4.25f, 0),
        new Vector3(1.7f, -4.25f, 0)
    };
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void IncrementFruit()
    {
        fruitCount += 1;
        fruitScore.SetText(String.Format("x {0}", fruitCount) );
    }

    public void GameOver(bool won = false)
    {
        if (won)
        {
            //TODO 
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);
        }
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        ClearGame();
        fruitCount = 0;
        fruitScore.SetText("x 0");
        restartButton.gameObject.SetActive(false);
        GameObject player = Instantiate(playerPrefab, playerLocation, Quaternion.identity);
        gameObject.GetComponent<ShowHiddenArea>().SetPlayer(player);
        for (int i = 0; i < appleLocs.Length; i++)
        {
            Instantiate(applePrefab, appleLocs[i], Quaternion.identity);
        }
        GameObject cam = GameObject.FindGameObjectWithTag("Cinemachine");
        cam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
    }

    private void ClearGame()
    { 
        GameObject[] leftovers = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (GameObject fruit in leftovers)
        {
            Destroy(fruit);
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        foreground.gameObject.SetActive(true);
    }
}
