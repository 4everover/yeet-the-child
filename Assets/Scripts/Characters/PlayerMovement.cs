using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider; 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private int playerNum;

    private float sizeScale;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sizeScale = Mathf.Abs(transform.localScale.x);
    }

    private void Start()
    {
        if (playerNum == 2) { transform.localScale = new Vector3(-sizeScale, sizeScale, sizeScale); }
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("HorizontalP" + playerNum);

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flips player when facing left
        if (horizontalInput > 0.0f)
        {
            transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
        }
        else if (horizontalInput < 0.0f)
        {
            transform.localScale = new Vector3(-sizeScale, sizeScale, sizeScale);
        }

        if (Input.GetAxisRaw("VerticalP" + playerNum) > 0 && isGrounded())
        {
            Jump();
        }
    }

    public int GetPlayerNum() { return playerNum; }
    public void SetPlayerNum(int n) { playerNum = n; }
    
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumppower);
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
