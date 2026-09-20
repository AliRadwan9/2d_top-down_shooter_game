using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject gun;
    public PlayerHp playerHp;
    public float fireRate = 0.5f; 

    private GameObject bullet;
    private float nextFireTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        nextFireTime = Time.time + fireRate;

        bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        playerHp.DamagePlayer(1);

    }
}

