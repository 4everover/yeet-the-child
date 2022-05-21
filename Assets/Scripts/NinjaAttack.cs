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
    private float lifetime1;
    private float lifetime2;
    private Animator anim;
    //private BoxCollider2D boxCollider;
    //private Rigidbody2D body;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
        //body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        if(Input.GetKey(KeyCode.Comma) && cooldownTimer1 >= attackCooldown1)
        {
            cooldownTimer1 = 0;
            lifetime1 = 0;
            anim.SetTrigger("Attack");
            area.transform.position = attackPos.position;
        }

        if (lifetime1 > 0.1f)
        {
            area.transform.position = new Vector2(69, 420);
        }

        lifetime1 += Time.deltaTime;

        cooldownTimer1 += Time.deltaTime;

        if(Input.GetKey(KeyCode.Period) && cooldownTimer2 >= attackCooldown2)
        {
            cooldownTimer2 = 0;
            lifetime2 = 0;
            anim.SetTrigger("Attack2");

            if (transform.localScale.x > 0)
            {
                anim.SetTrigger("Attack2");
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
                anim.SetTrigger("Attack2");
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
        
        if (lifetime2 > 0.5f)
        {
            area2.transform.position = new Vector2(420, 69);
        }

        lifetime2 += Time.deltaTime;

        cooldownTimer2 += Time.deltaTime;  
    }
}
