using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    //transform of the camera to shake
    private Transform shakeableObject;

    //Desired duration of the shake effect
    private float shakeDuration = 0.1f;

    //Magnitude of the shaking
    private float shakeMagnitude = 0.7f;

    //A measure of how quickly the shake will end
    private float dampingSpeed = 1.0f;

    //Initial position of the shakeableObject
    Vector3 initialPosition;

    void Awake()
    {
        if (shakeableObject == null)
        {
            shakeableObject = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }

        else
        {
            shakeDuration = 0;
            transform.localPosition = initialPosition;
        }
    }

    void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
