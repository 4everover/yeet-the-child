using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damageToDeal;
    [SerializeField] private float speed;
    [SerializeField] private float howMuchLifetime;

    [SerializeField] private bool isDroppable;
    [SerializeField] private bool isThrowable;
    [Header("Only if throwable (\"Speed\" will be x vel):")]
    [SerializeField] private float throwingYVelocity;

    private bool hit;
    private float direction;
    private float lifetime;

    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;

    private GameObject summoner;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        hit = false;
        lifetime = 0;
    }
    private void Start()
    {
        if (isThrowable)
        {
            body.velocity = new Vector2(direction * speed, throwingYVelocity);
        }
    }

    private void Update()
    {
        if (hit) 
        {
            Destroy(gameObject);
        }
        if (lifetime > howMuchLifetime)
        {
            Destroy(gameObject);
        }

        float movementSpeed = direction * speed;

        if (!isThrowable && !isDroppable) { body.velocity = new Vector2(movementSpeed, 0); }
        lifetime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == summoner) { return; }
        else if (collision.GetComponent<Health>()) 
        {
            collision.GetComponent<Health>().TakeDamage(damageToDeal);
        }
        hit = true;
    }

    public void SetSummoner(GameObject gO) { summoner = gO; }

    public GameObject GetSummoner() { return summoner; }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        transform.localScale = new Vector3(direction*transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }
}
