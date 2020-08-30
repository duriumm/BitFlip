using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonScripts : MonoBehaviour
{

    public AudioSource clickSound;

    public GameObject howToPlayMenuPANEL;
    public GameObject mainMenuPanel;

    private bool isInSideHowToPlayMenu = false;



    public void Start()
    {
        //howToPlayMenuPANEL.SetActive(true);
        howToPlayMenuPANEL.SetActive(false); // OM OBJEKTET ÄR FALSE PÅ SET ACTIVE I BÖRJAN SÅ KAN MAN TYP
                                            // INTE INTERACTA MED DET. MÅSTE LÖSAS
        mainMenuPanel.SetActive(true);
    }
    private void Update()
    {
        //print("getActive status of isInsideHowToPlayMenu: " + howToPlayMenuPANEL.activeSelf);
    }
    public void OnClickPlayButton()
    {
        print("bool status of isInsideHowToPlayMenu: "+isInSideHowToPlayMenu);
        if (isInSideHowToPlayMenu == false)
        {
            StartCoroutine(WaitBeforeSceneStart(1, "GameScene"));  
        }
           
    }
    public void OnClickHowToPlayButton()
    {
        clickSound.Play();
        print("sound played");
        howToPlayMenuPANEL.SetActive(true);
        print("howto play menu status: "+howToPlayMenuPANEL.activeSelf);
        mainMenuPanel.SetActive(false);
        print("main menu panel status: " + mainMenuPanel.activeSelf);
        isInSideHowToPlayMenu = true;
        print("getActive status of isInsideHowToPlayMenu: " + howToPlayMenuPANEL.activeSelf);
        //print("bool status of isInsideHowToPlayMenu: " + isInSideHowToPlayMenu);
    }
    public void OnClickReturnFromHowToPlayMenu()
    {        
        clickSound.Play();
        isInSideHowToPlayMenu = false;
        mainMenuPanel.SetActive(true);
        howToPlayMenuPANEL.SetActive(false);
        print("getActive status of isInsideHowToPlayMenu: " + mainMenuPanel.activeSelf);
        //print("(onclickreturnfromHowtoplay) -> bool status of isInsideHowToPlayMenu: " + isInSideHowToPlayMenu);
    }

    IEnumerator WaitBeforeSceneStart(int secondsToWait, string sceneToLoad)
    {
        
        clickSound.Play();
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(sceneToLoad);
    }
}
