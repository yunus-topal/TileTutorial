using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int fruitCount = 0;

    public TextMeshProUGUI fruitScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementFruit()
    {
        fruitCount += 1;
        fruitScore.SetText(String.Format("x {0}", fruitCount) );
    }
}
