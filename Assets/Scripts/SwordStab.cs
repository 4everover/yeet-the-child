using UnityEngine;

public class SwordStab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "General")
        {
            Debug.Log("Ouch");
        }
    }
}
