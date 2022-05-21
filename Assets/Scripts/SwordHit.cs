using UnityEngine;

public class SwordHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "General")
        {
            Debug.Log("Oof");
        }
    }
}
