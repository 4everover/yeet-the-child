using UnityEngine;

public class SwordStab : MonoBehaviour
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
            collision.GetComponent<Health>().TakeDamage(ninjaAttack.GetAttack2Damage());
            //Debug.Log("Ouch");
        }
    }
}
