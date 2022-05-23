using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] int whichPlayer;
    Slider slider;
    Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        GetCorrectPlayer();
        slider.maxValue = playerHealth.GetStartingHealth();
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth) { slider.value = playerHealth.GetHealth(); }
        else 
        {
            FindObjectOfType<WinnerScreen>().EnableWinScreen();
            Destroy(gameObject); 
        }
    }

    void GetCorrectPlayer()
    {
        var players = FindObjectsOfType<PlayerMovement>();
        foreach (var p in players)
        {
            if (p.GetPlayerNum() == whichPlayer)
            {
                playerHealth = p.GetComponent<Health>();
                break;
            }
        }
    }
}
