using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    private int lightMode;
    public Animation torchLight;

    // Update is called once per frame
    void Update()
    {
        if(lightMode == 0)
            StartCoroutine(AnimateLight());
    }

    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
            torchLight.Play("TorchAnime1");
        if (lightMode == 2)
            torchLight.Play("TorchAnime2");
        if (lightMode == 3)
            torchLight.Play("TorchAnime3");

        yield return new WaitForSeconds(1);

        lightMode = 0;
    }
}
