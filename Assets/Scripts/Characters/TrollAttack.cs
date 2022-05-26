using UnityEngine;

public class TrollAttack : MonoBehaviour
{   
    private PlayerMovement playerMovement;
    
    [SerializeField] private Transform catPoint;

    [SerializeField] private GameObject cat;


    [SerializeField] private Transform dogePoint;
    [SerializeField] private GameObject doge;

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
        GameObject instantiatedDoge = Instantiate(doge, dogePoint.transform.position, Quaternion.identity);
        instantiatedDoge.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedDoge.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));    
    }

}