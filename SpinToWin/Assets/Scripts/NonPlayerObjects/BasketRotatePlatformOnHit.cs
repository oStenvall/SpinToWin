using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;

public class BasketRotatePlatformOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platform;
    public Transform referenceObject;
    public Light2D lightSource;
    public int blinkTime;
    public int numberOfBlinks;
    private IEnumerator coroutine;


    public bool isTimedPlatform;
    public float resetTime;
    private Quaternion originalRotation;
    private float timeLeft = 0;
    private bool timerStarted = false;

    private void Start()
    {
        originalRotation = referenceObject.transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!isTimedPlatform)
            {
                RotatePlatform();
            }else
            {
                RotateTimedPlatform();
            }
        }
    }

    void Update()
    {
        platform.rotation = Quaternion.Slerp(platform.transform.rotation, referenceObject.rotation, 5f * Time.deltaTime);
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0 && timerStarted) {
            Debug.Log("Hej");
            timerStarted = false;
            referenceObject.Rotate(new Vector3(0, 0, 90));
        }
    }

    void RotatePlatform()
    {
        referenceObject.Rotate(new Vector3(0, 0, -90));
        coroutine = flashNow();
        StartCoroutine(coroutine);

    }

    void RotateTimedPlatform()
    {
        timerStarted = true;
        timeLeft = resetTime;
        referenceObject.Rotate(new Vector3(0, 0, -90));
        coroutine = flashNow();
        StartCoroutine(coroutine);
    }

    public IEnumerator flashNow()
    {
        float waitTime = blinkTime / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        for (int i = 0; i< numberOfBlinks; i++)
        {
            //float sphereRadiusMax = lightSource. * 4;
            //float sphereRadiusMin = lightSource.gameObject.sphereRadius * 4;
            while (lightSource.intensity < 1)
            {
                lightSource.intensity += 0.05f;        // Increase intensity
                yield return new WaitForSeconds(0.01f);
            }
            lightSource.intensity = 1;
            while (lightSource.intensity > 0)
            {
                lightSource.intensity -= 0.05f;        //Decrease intensity
                yield return new WaitForSeconds(0.01f);
            }
            lightSource.intensity = 0;
        }
        
        yield return null;
    }
}
