using UnityEngine;

public class Health : MonoBehaviour
{
    private float attackCooldown;
    //[SerializeField] public float startTime;
    [SerializeField] private float startingHealth = 100;
    [SerializeField] private float damageCooldown = 0.1f;
    private float damageTimer;

    [Header("ONLY SERIALIZED FOR DEBUG")]
    [SerializeField] private float currentHealth;

    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        damageTimer = 0;
    }

    public void TakeDamage(float _damage)
    {
        if (damageTimer >= damageCooldown) { currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); }

        if (currentHealth > 0)
        {
            //anim.SetTrigger("attack1");
            Debug.Log(gameObject.name + " health: " + currentHealth);
            GetComponent<SpriteRenderer>().color = Color.red;
            damageTimer = 0;
        }
        else
        {
            Destroy(gameObject, 1);
            GetComponent<Collider2D>().enabled = false;
            if (GetComponent<NinjaAttack>()) { GetComponent<NinjaAttack>().enabled = false; }
            if (GetComponent<PlayerAttack>()) { GetComponent<PlayerAttack>().enabled = false; }
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.5f);
        }
    }

    private void Update()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageCooldown && currentHealth > 0) { GetComponent<SpriteRenderer>().color = Color.white; }
        /*if (attackCooldown <= 0)
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
        }*/
    }

    public float GetHealth() { return currentHealth; }

    public float GetStartingHealth() { return startingHealth; }
}
