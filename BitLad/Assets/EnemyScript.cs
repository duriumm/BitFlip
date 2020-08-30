using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{

    private Vector3 startingPosition;
    private GameObject thisEnemy;

    private TextMeshPro followingText;

    public float speed;

    public int randomDecimalNumber;

    public AudioSource losingSound;
    

    void Start()
    {

        print("Current scene: "+SceneManager.GetActiveScene().name);
        randomDecimalNumber = UnityEngine.Random.Range(1, 256);
        startingPosition = transform.position;
        thisEnemy = this.gameObject;

        followingText = GetComponentInChildren<TextMeshPro>();
        followingText.text = randomDecimalNumber.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * Time.deltaTime * speed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(WaitBeforeRestartScene(2));
        }
    }
    public void resetEnemy() 
    {
        thisEnemy.transform.position = startingPosition;
        randomDecimalNumber = UnityEngine.Random.Range(1, 256);
        followingText.text = randomDecimalNumber.ToString();
    }
    IEnumerator WaitBeforeRestartScene(int secondsToWait)
    {
        speed = 0;
        losingSound.Play();        
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene("GameScene");
    }
}
