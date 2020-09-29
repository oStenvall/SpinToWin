using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketRotatePlatformOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platform;
    public Transform referenceObject;
   

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
        
    }

    void RotateTimedPlatform()
    {
        timerStarted = true;
        timeLeft = resetTime;
        referenceObject.Rotate(new Vector3(0, 0, -90));
    }
}
