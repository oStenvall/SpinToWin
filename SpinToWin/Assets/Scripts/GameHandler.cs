using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    //public List<Transform> spinningPlatforms;
    public Transform platform;
    Quaternion currentPlayerRotation;
    // Start is called before the first frame update

    void Update()
    {
        if(platform.transform.rotation != currentPlayerRotation)
        {
            RotatePlatforms();
        }
    }

    public void UpdatePlayerRotation(Quaternion playerRotation)
    {
        currentPlayerRotation = playerRotation;
    }

    void RotatePlatforms()
    {
        platform.transform.rotation = Quaternion.Slerp(platform.transform.rotation, currentPlayerRotation, 5f * Time.deltaTime);
    }

  
}