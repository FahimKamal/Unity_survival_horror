using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJumpTrigger : MonoBehaviour
{
    public AudioSource doorBang;
    public AudioSource ambMusic;
    public AudioSource doorJumpMusic;
    public GameObject theZombie;
    public GameObject theDoor;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().enabled = false;
        theDoor.GetComponent<Animation>().Play("JumpDoorAnim");
        theZombie.SetActive(true);
                
        doorBang.Play();

        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        ambMusic.Stop();
        doorJumpMusic.Play();
    }
}
