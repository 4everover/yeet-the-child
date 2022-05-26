using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject[] p1Characters;
    [SerializeField] GameObject[] p2Characters;
    [SerializeField] GameObject[] spawnpoints;
    static GameObject player1Selection;
    static GameObject player2Selection;
    Scene currentScene;

    // Start is called before the first frame update
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        if (currentScene.name == "Fatality!")
        {
            GameObject p1;
            GameObject p2;
            
            if (player1Selection) 
            { 
                p1 = Instantiate(player1Selection, spawnpoints[0].transform);
            }
            else
            {
                p1 = Instantiate(p1Characters[0], spawnpoints[0].transform);
            }
            p1.GetComponent<PlayerMovement>().SetPlayerNum(1);
            
            if (player2Selection) 
            { 
                p2 = Instantiate(player2Selection, spawnpoints[1].transform); 
            }
            else
            {
                p2 = Instantiate(p1Characters[0], spawnpoints[0].transform);
            }
            p2.GetComponent<PlayerMovement>().SetPlayerNum(2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Player1Selection(int index)
    {
        player1Selection = p1Characters[index];
        Debug.Log("player 1 selected " + player1Selection.name);
    }
    public void Player2Selection(int index)
    {
        player2Selection = p2Characters[index];
        Debug.Log("player 2 selected " + player2Selection.name);
    }

    public static GameObject getPlayer1Selection() { return player1Selection; }
    public static GameObject getPlayer2Selection() { return player2Selection; }
}
