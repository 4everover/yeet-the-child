using UnityEngine;

public class MadSciAttack : MonoBehaviour
{ 
    private PlayerMovement playerMovement;
    
    [SerializeField] private Transform potionPoint;
    [SerializeField] private Transform gasPoint;
    [SerializeField] private GameObject potion;
    [SerializeField] private GameObject gas;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    private void Update()
    {

    }

    public void Attack1()
    {
        GameObject instantiatedPotion = Instantiate(potion, potionPoint.transform.position, Quaternion.identity);
        instantiatedPotion.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedPotion.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    public void Attack2()
    {
        GameObject instantiatedGas = Instantiate(gas, gasPoint.transform.position, Quaternion.identity);
        instantiatedGas.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedGas.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
