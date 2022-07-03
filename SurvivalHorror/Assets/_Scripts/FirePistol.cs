using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject gun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public int damageAmount = 5;

    public float targetDistance;

    private bool isFiring = false;

    void Update()
    {
        if (!isFiring && Input.GetButtonDown("Fire1") && GlobalAmmo.ammoCount >= 1)
        {
            GlobalAmmo.ammoCount -= 1;
            StartCoroutine(FiringPistol());
        }
    }

    IEnumerator FiringPistol()
    {
        isFiring = true;

        RaycastHit shot;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("DamageZombie", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        gun.GetComponent<Animation>().Play("PistolShot");
        muzzleFlash.SetActive(true);
        gunFire.Play();
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
        muzzleFlash.SetActive(false);
    }
}
