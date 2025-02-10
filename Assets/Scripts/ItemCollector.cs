using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int beers = 0;
    private int marlboro = 0;
    [SerializeField] private Text beersText;
    [SerializeField] private Text marlboroText;
    [SerializeField] private Text joker;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource boobSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Beer"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            beers++;
            beersText.text = "" + beers;
        }
        else if (collision.gameObject.CompareTag("Marlboro"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            marlboro++;
            marlboroText.text = "" + marlboro;
        }else if (collision.gameObject.CompareTag("Boobs"))
        {
            boobSound.Play();
        }else if (collision.gameObject.CompareTag("Joker"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            joker.text = "1";
        }
        
    }
}
