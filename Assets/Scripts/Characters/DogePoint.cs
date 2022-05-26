using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogePoint : MonoBehaviour
{
    [SerializeField] float dropHeight = 4;
    private PlayerMovement[] players;
    private GameObject opposingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement p in players)
        {
            if (p.gameObject != GetComponentInParent<PlayerMovement>().gameObject)
            {
                opposingPlayer = p.gameObject;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(opposingPlayer.transform.position.x, dropHeight);
    }
}
