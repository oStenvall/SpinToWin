using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform platform;
    public Transform referenceObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            RotatePlatform();
        }
    }

    void Update()
    {
        platform.rotation = Quaternion.Slerp(platform.transform.rotation, referenceObject.rotation, 5f * Time.deltaTime);
    }

    void RotatePlatform()
    {
        referenceObject.Rotate(new Vector3(0, 0, -90));
    }
}
