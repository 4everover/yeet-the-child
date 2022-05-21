using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float howMuchLifetime = 3;
    private bool hit;
    private float direction;
    private float lifetime;

    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        float movementSpeed = -1 * speed * Time.deltaTime * direction;
        //body.velocity = new Vector2(movementSpeed, 12);
    }

    private void Update()
    {
        if (hit) return;
        
        //body.velocity = new Vector2(body.velocity.x, body.velocity.y);

        lifetime += Time.deltaTime;
        if (lifetime > howMuchLifetime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<GeneralAttack>()) { return; }
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Explode");
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
