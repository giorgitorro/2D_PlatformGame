using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 respawnPoint;
    private bool checkpoint = false;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource death2Sound;
    [SerializeField] private AudioSource killSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.gameObject.CompareTag("Trap"))
        {
            killSound.Play();
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("checkpoint"))
        {
            respawnPoint = transform.position;
            checkpoint = true;
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  if (collision.gameObject.CompareTag("Trap"))
        {
            if (checkpoint)
            {
                Spawn();
            }
            else
            {
                Die();
            }
            
        }       
    }

    private void Die()
    {
        deathSound.Play();
        death2Sound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Spawn()
    {
        deathSound.Play();
        death2Sound.Play();
        anim.SetTrigger("checkpointDeath");
        rb.position = respawnPoint;
        anim.ResetTrigger("checkpointDeath");
    }
}
