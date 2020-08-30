using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro.TextMeshProUGUI;
using UnityEngine;
using UnityEngine.UI;

public class BinaryButtonScript : MonoBehaviour
{

    private TextMeshProUGUI binaryNumberText;
    public string stringBinaryValue = "0";
    public bool isButtonPressed = false;

    public GameObject scriptManagerObject;

    public AudioSource clickSound;
    
    void Awake()
    {
        binaryNumberText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        stringBinaryValue = "0";
        //scriptManagerObject.GetComponent<CalculationManager>(); // VAD GÖR DENNA????
    }
    void Start()
    {
       
    }
    public void ChangeBinaryNumber()
    {
        
        if(binaryNumberText.text == "0")
        {
            clickSound.Play();
            binaryNumberText.text = "1";
            stringBinaryValue = "1";
            scriptManagerObject.GetComponent<CalculationManager>().GetAllBinaryAndConvertToDecimal(false);
        }
        else if(binaryNumberText.text == "1")
        {
            clickSound.Play();
            binaryNumberText.text = "0";
            stringBinaryValue = "0";
            scriptManagerObject.GetComponent<CalculationManager>().GetAllBinaryAndConvertToDecimal(false);
        }
        
    }
    public string returnStringValue()
    {
        return stringBinaryValue;
    }
}
