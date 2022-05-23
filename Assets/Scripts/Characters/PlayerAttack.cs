using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown1;
    [SerializeField] private float attackCooldown2;
    private float cooldownTimer1;
    private float cooldownTimer2;

    private Animator anim;
    private PlayerMovement playerMovement;
    private int playerNum;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerNum = playerMovement.GetPlayerNum();

        cooldownTimer1 = Mathf.Infinity;
        cooldownTimer2 = Mathf.Infinity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("AttackP" + playerNum) > 0 && cooldownTimer1 >= attackCooldown1) { PrimaryAttack(); }
        else if (Input.GetAxisRaw("AttackP" + playerNum) < 0 && cooldownTimer2 >= attackCooldown2) { SecondaryAttack(); }

        cooldownTimer1 += Time.deltaTime;
        cooldownTimer2 += Time.deltaTime;
    }

    void PrimaryAttack()
    {
        anim.SetTrigger("attack1");
        //Debug.Log(gameObject.name + " attack1");
        cooldownTimer1 = 0;
    }

    void SecondaryAttack()
    {
        anim.SetTrigger("attack2");
        //Debug.Log(gameObject.name + " attack2");
        cooldownTimer2 = 0;
    }
}
