using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject bullet;

    [Header("Settings")]
    public int ammo;
    public float rpm;

    [Header("Shoot")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float bulletForce;
    public float bulletUpwardForce;

    bool readyToShoot;

    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey)&& readyToShoot && ammo > 0)
        {
            Buudah();
        }
    }

    void Buudah()
    {
        readyToShoot = false;
        GameObject projectile = Instantiate(bullet, attackPoint.position, cam.rotation);
        Rigidbody bulletRB = projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = cam.transform.forward * bulletForce + transform.up * bulletForce;

        bulletRB.AddForce(forceToAdd, ForceMode.Impulse);
        ammo--;
        Invoke(nameof(ResetShoot), rpm);
    }
    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
