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
    public Button exitButton;

    public GameObject playerPrefab;
    private Vector3 playerLocation = new Vector3(-4f, -1.2f, 0);

    public GameObject applePrefab;
    public GameObject blueBirdPrefab;
    
    public GameObject foreground;

    [SerializeField] private Collectable[] apples;
    [SerializeField] private BlueBird[] birds;
    
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
        exitButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        ClearGame();
        fruitCount = 0;
        fruitScore.SetText("x 0");
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        GameObject player = Instantiate(playerPrefab, playerLocation, Quaternion.identity);
        gameObject.GetComponent<ShowHiddenArea>().SetPlayer(player);
        
        // spawn apples
        foreach (Collectable apple in apples)
        {
            Instantiate(applePrefab, apple.Position, Quaternion.identity);
        }
        
        // spawn birds
        foreach (BlueBird bird in birds)
        {
            GameObject o = Instantiate(blueBirdPrefab, bird.StartPosition, Quaternion.identity);
            o.GetComponent<OscillateMovement>().SetOscillation(bird.StartPosition, bird.TargetPosition, bird.Speed, bird.WaitTime);
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
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        foreground.gameObject.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
