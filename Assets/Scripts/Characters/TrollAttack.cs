using UnityEngine;

public class TrollAttack : MonoBehaviour
{   
    private PlayerMovement playerMovement;
    
    [SerializeField] private Transform catPoint;
    //[SerializeField] private Transform bombPoint;
    //[SerializeField] private GameObject[] bullets;
    //[SerializeField] private GameObject[] bombs;
    [SerializeField] private GameObject cat;
    //[SerializeField] private GameObject bomb;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    private void Update()
    {

    }

    public void Attack1()
    {
        GameObject instantiatedCat = Instantiate(cat, catPoint.transform.position, Quaternion.identity);
        instantiatedCat.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedCat.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    public void Attack2()
    {
        //anim.SetTrigger("attack2");
        //cooldownTimer2 = 0;

        //bombs[FindBomb()].transform.position = bombPoint.position;
        //bombs[FindBomb()].SetActive(true);
        //bombs[FindBomb()].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));

        //bullets[FindBomb()].transform.position = firePoint.position;
        //bullets[FindBomb()].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));

        //GameObject instantiatedBomb = Instantiate(bomb, bombPoint.transform.position, Quaternion.identity);
        //instantiatedBomb.GetComponent<Projectile>().SetSummoner(gameObject);
        //instantiatedBomb.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}