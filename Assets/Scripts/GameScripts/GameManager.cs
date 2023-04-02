using System;
using System.Collections;
using System.Collections.Generic;
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
        
    }

    public void IncrementFruit()
    {
        fruitCount += 1;
        fruitScore.SetText(String.Format("x {0}", fruitCount) );
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        ClearGame();
        fruitCount = 0;
        fruitScore.SetText("x 0");
        restartButton.gameObject.SetActive(false);
        Instantiate(playerPrefab, playerLocation, Quaternion.identity);
        for (int i = 0; i < appleLocs.Length; i++)
        {
            Instantiate(applePrefab, appleLocs[i], Quaternion.identity);
        }
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
    }
}
