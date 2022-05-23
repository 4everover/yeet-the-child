using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerScreen : MonoBehaviour
{
    [SerializeField] GameObject winScreenItems;

    // Start is called before the first frame update
    void Start()
    {
        winScreenItems.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableWinScreen()
    {
        winScreenItems.SetActive(true);
    }
}
