using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public GameObject theFlashScreen;
    public float enemyWalkSpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;

    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    private int hurtGen;

    private Vector3 relativePos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackTrigger = false;
            theEnemy.GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    void Update()
    {
        // Only rotate the y not x and z.
        var relativePos = thePlayer.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(relativePos).eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);

        if(attackTrigger == false)
        {
            enemyWalkSpeed = 0.01f;

            var enemyPos = theEnemy.transform.position;
            var playerPos = thePlayer.transform.position;
            relativePos = Vector3.MoveTowards(enemyPos, playerPos, enemyWalkSpeed);
            transform.position = new Vector3(relativePos.x, enemyPos.y, relativePos.z);
        }

        if(attackTrigger == true && isAttacking == false)
        {
            enemyWalkSpeed = 0;
            theEnemy.GetComponent<Animator>().SetBool("isAttacking", true);
            StartCoroutine(InflactDamage());
        }
    }

    IEnumerator InflactDamage()
    {
        isAttacking = true;

        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
            hurtSound1.Play();
        else if (hurtGen == 2)
            hurtSound2.Play();
        else if (hurtGen == 3)
            hurtSound3.Play();
        theFlashScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlashScreen.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;        
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
