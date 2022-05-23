using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damageToDeal;
    [SerializeField] private float speed;
    [SerializeField] private float howMuchLifetime;

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
            //gameObject.SetActive(false); 
        }
        if (lifetime > howMuchLifetime)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }

        float movementSpeed = direction * speed;

        if (!isThrowable) { body.velocity = new Vector2(movementSpeed, 0); }
        //else { body.velocity = new Vector2(movementSpeed, body.velocity.y); }

        //transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == summoner) { return; }
        else if (collision.GetComponent<Health>()) 
        {
            //Debug.Log(collision.name + " has health");
            collision.GetComponent<Health>().TakeDamage(damageToDeal);
        }
        hit = true;
        //boxCollider.enabled = false;
        //anim.SetTrigger("Explode");
    }

    public void SetSummoner(GameObject gO) { summoner = gO; }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        transform.localScale = new Vector3(direction*transform.localScale.x, transform.localScale.y, transform.localScale.z);

        /*lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;


        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);*/

    }

    /*private void Deactivate()
    {
        gameObject.SetActive(false);
    }*/
}
