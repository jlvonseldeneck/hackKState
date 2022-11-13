using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPref;

    public int ammo = 15;

    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                ammo--;
                FindObjectOfType<AudioHandler>().playShoot();
                GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            }
        }
    }

    public void addAmmo() {
        ammo++;
    }

    public int getAmmo() {
        return ammo;
    }
}
