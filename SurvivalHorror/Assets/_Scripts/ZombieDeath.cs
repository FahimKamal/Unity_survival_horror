using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int enemyHealth = 20;
    public GameObject theEnemy;
    public int statusCheck;
    public AudioSource ampMusic;
    public AudioSource jumpScareMusic;

    private void  DamageZombie(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }


    void Update()
    {
        if(enemyHealth <= 0 && statusCheck == 0)
        {
            statusCheck = 2;
            theEnemy.GetComponent<Animator>().SetBool("isDead", true);
            theEnemy.GetComponent<ZombieAI>().enabled = false;
            theEnemy.GetComponent<BoxCollider>().enabled = false;
            
            jumpScareMusic.Stop();
            ampMusic.Play();
        }
    }
}
