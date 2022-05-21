using UnityEngine;

public class Health : MonoBehaviour
{
    private float attackCooldown;
    [SerializeField] public float startTime;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("attack1");
        }
        else
        {
            if (!dead)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (attackCooldown <= 0)
        {

            if(Input.GetKey(KeyCode.E))
            {
                TakeDamage(0.2f);
                Debug.Log("Ouch: " + currentHealth);
            }

            attackCooldown = startTime;
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
}
