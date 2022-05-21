using UnityEngine;

public class GeneralAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown1;
    [SerializeField] private float attackCooldown2;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bombPoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private GameObject[] bombs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer1 = Mathf.Infinity;
    private float cooldownTimer2 = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.C) && cooldownTimer1 >= attackCooldown1) //&& playerMovement.canAttack())
        {
            Attack1();
        }

        if(Input.GetKey(KeyCode.V) && cooldownTimer2 >= attackCooldown2) //&& playerMovement.canAttack())
        {
            Attack2();
        }

        cooldownTimer1 += Time.deltaTime;
        cooldownTimer2 += Time.deltaTime;

    }

    private void Attack1()
    {
        anim.SetTrigger("attack1");
        cooldownTimer1 = 0;

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void Attack2()
    {
        anim.SetTrigger("attack2");
        cooldownTimer2 = 0;

        bombs[FindBomb()].transform.position = bombPoint.position;
        bombs[FindBomb()].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));

       //bullets[FindBomb()].transform.position = firePoint.position;
       //bullets[FindBomb()].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i = i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private int FindBomb()
    {
        for (int i = 1; i < bombs.Length; i = i + 2)
        {
            if (!bombs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

}
