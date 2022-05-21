using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] 
    private float speed = 13;
    [SerializeField] private float howMuchLifetime = 3;
    private bool hit;
    private float direction;
    private float lifetime;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = 1 * speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

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
