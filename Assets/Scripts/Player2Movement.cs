using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D body;
    //private Animator anim;
    private BoxCollider2D boxCollider; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("HorizontalP2");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flips player when facing left
        if (horizontalInput > 0.0f)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
        else if (horizontalInput < 0.0f)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumppower);
    }

    public void setSpeed(float s)
    {
        speed = s;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}

