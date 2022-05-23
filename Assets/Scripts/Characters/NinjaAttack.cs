using UnityEngine;

public class NinjaAttack : MonoBehaviour
{
    private float cooldownTimer1;
    private float cooldownTimer2;
    [SerializeField] private float attackCooldown1;
    [SerializeField] private float attackCooldown2;
    [SerializeField] private Transform attackPos;
    [SerializeField] private GameObject area;
    [SerializeField] private Transform attackPos2;
    [SerializeField] private GameObject area2;

    [Header("damage to deal (for each attack)")]
    [SerializeField] private float attack1Damage = 2.5f;
    [SerializeField] private float attack2Damage = 7.5f;

    private float lifetime1;
    private float lifetime2;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private float playerNum;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerNum = GetComponent<PlayerMovement>().GetPlayerNum();
        //boxCollider = GetComponent<BoxCollider2D>();
        //body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        if(Input.GetAxisRaw("AttackP" + playerNum) > 0 && cooldownTimer1 >= attackCooldown1)
        {
            cooldownTimer1 = 0;
            lifetime1 = 0;
            anim.SetTrigger("attack1");
            area.transform.position = attackPos.position;
        }

        else if(Input.GetAxisRaw("AttackP" + playerNum) < 0 && cooldownTimer2 >= attackCooldown2)
        {
            cooldownTimer2 = 0;
            lifetime2 = 0;
            anim.SetTrigger("attack2");

            if (transform.localScale.x > 0)
            {
                anim.SetTrigger("attack2");
                for (int i = 0; i < 50; i++)
                {
                    area2.transform.position = attackPos2.position;
                    transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
                    if (transform.position.x > 10)
                    {
                        break;
                    }
                }
            }
            else if (transform.localScale.x < 0)
            {
                anim.SetTrigger("attack2");
                for (int i = 0; i < 50; i++)
                {
                    area2.transform.position = attackPos2.position;
                    transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
                    if (transform.position.x < -10)
                    {
                        break;
                    }
                }
            }

        }

        if (lifetime1 > 0.1f)
        {
            area.transform.position = new Vector2(69, 420);
        }

        lifetime1 += Time.deltaTime;

        cooldownTimer1 += Time.deltaTime;

        if (lifetime2 > 0.5f)
        {
            area2.transform.position = new Vector2(420, 69);
        }

        lifetime2 += Time.deltaTime;

        cooldownTimer2 += Time.deltaTime;  
    }

    public float GetAttack1Damage() { return attack1Damage; }
    public float GetAttack2Damage() { return attack2Damage; }
}
