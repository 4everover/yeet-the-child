using UnityEngine;

public class GeneralAttack : MonoBehaviour
{ 

    
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bombPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        
    }

    private void Update()
    {

    }

    public void Attack1()
    {

        GameObject instantiatedBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        instantiatedBullet.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedBullet.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    public void Attack2()
    {

        GameObject instantiatedBomb = Instantiate(bomb, bombPoint.transform.position, Quaternion.identity);
        instantiatedBomb.GetComponent<Projectile>().SetSummoner(gameObject);
        instantiatedBomb.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
