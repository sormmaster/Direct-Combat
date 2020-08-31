using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int onHitVal = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;
    void Start()
    {
        setHealth();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health -= onHitVal;
        setHealth();
        if(health <= 0)
        {
            print("GAME OVER");
            Application.Quit();
        }
    }

    private void setHealth()
    {
        healthText.text = health.ToString();
    }
}
