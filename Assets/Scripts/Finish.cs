using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private bool levelCompleted = false;
    [SerializeField] private AudioSource finishSound2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound2.Play();
            finishSound.Play();
            levelCompleted = true;
            Invoke(nameof(CompleteGame), 2f);
        }
    }

    private void CompleteGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
