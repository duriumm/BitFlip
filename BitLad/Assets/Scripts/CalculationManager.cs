using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class CalculationManager : MonoBehaviour
{
    private GameObject binaryNumberObject;

    public GameObject enemyObject;
    public GameObject actualScoreObject;
    public GameObject actualHiScoreObject;
    public GameObject currentTotalBinaryValue;

    private int enemyDecimalNumber;

    public AudioSource getPointSound;

    private int integerCurrentScore = 0;
    private int integerCurrentHiScore = 0; // inte implementerat än fixa save feature
    private bool isResultOfBinaryNumberBox = false;
   
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI hiScoreText; // inte implementerat än fixa save feature
    private TextMeshProUGUI currentTotalBinaryValueText;

    void Start()
    {
        scoreText = actualScoreObject.GetComponentInChildren<TextMeshProUGUI>();
        hiScoreText = actualHiScoreObject.GetComponentInChildren<TextMeshProUGUI>();
        currentTotalBinaryValueText = currentTotalBinaryValue.GetComponentInChildren<TextMeshProUGUI>();

        hiScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        integerCurrentScore = 0;
        //integerCurrentHiScore = 0;
    }
    private void Update()
    {
        GetAllBinaryAndConvertToDecimal(true);
    }
    public void SaveScoreToHighScore()
    {
        PlayerPrefs.SetInt("HighScore", integerCurrentHiScore);
    }


    public void GetAllBinaryAndConvertToDecimal(bool isTotalBinaryValue)
    {
        enemyDecimalNumber = enemyObject.GetComponent<EnemyScript>().randomDecimalNumber; // hämtar fiendens decimalNummer
        string testValue = "";

        for (int i = 0; i < 8; i++) // loopar 8 gånger med inkrementation så Button0-Button7 hittas och sen += till en string
        {
            binaryNumberObject = GameObject.Find("Button" + i.ToString());
            testValue += binaryNumberObject.GetComponent<BinaryButtonScript>().stringBinaryValue;
        }
        print("värdet innan convert(string) = " + testValue); // testskrivning av värdet INNAN convert som en string också
        int convertedDecimalnumberFromBinary = Convert.ToInt32(testValue, 2); // convertar från binary till decimal
        print("DECIMAL after conversion = " + convertedDecimalnumberFromBinary); // testskrivning av Decimalvärdet

        if (convertedDecimalnumberFromBinary.Equals(enemyDecimalNumber) && isTotalBinaryValue.Equals(false)) // Lyckas du så¨spelas ljud och fienden resettas
        {
            integerCurrentScore++;
            scoreText.text = integerCurrentScore.ToString();
            if(integerCurrentScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", integerCurrentScore);
            }

            getPointSound.Play();
            enemyObject.GetComponent<EnemyScript>().resetEnemy();
        }
        else
        {
            currentTotalBinaryValueText.text = convertedDecimalnumberFromBinary.ToString();
        }

    }
}
