using UnityEngine;

public class SwordHit : MonoBehaviour
{
    private NinjaAttack ninjaAttack;

    private void Awake()
    {
        ninjaAttack = GetComponentInParent<NinjaAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GetComponentInParent<PlayerMovement>().gameObject) { return; }
        else if (collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<Health>().TakeDamage(ninjaAttack.GetAttack1Damage());
            //Debug.Log("Ouch");
        }
    }
}
