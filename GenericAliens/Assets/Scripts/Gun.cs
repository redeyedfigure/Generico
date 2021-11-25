using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public GameObject Flare;
    public int GunRecoilTime;
    private bool CoroutineIsNotRunning = true;
    public CameraShake cameraShake;

    IEnumerator DisableFlare(float waitTime)
    {
    CoroutineIsNotRunning = false;
    yield return new WaitForSeconds(waitTime);
    Flare.SetActive(false);
    CoroutineIsNotRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && CoroutineIsNotRunning == true)
        {
            Flare.SetActive(true);
            StartCoroutine(DisableFlare(GunRecoilTime));
            StartCoroutine(cameraShake.Shake(.15f, .4f));

        }

    }
}
