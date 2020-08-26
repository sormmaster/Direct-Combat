using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int onHitVal = 1;
    [SerializeField] Text healthText;

    void Start()
    {
        setHealth();
    }
    private void OnTriggerEnter(Collider other)
    {
        health -= onHitVal;
        setHealth();
    }

    private void setHealth()
    {
        healthText.text = health.ToString();
    }
}
