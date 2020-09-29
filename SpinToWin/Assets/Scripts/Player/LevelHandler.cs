using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    public List<Transform> Platforms;
    //public List<Transform> spinningPlatforms;
    Quaternion currentPlayerRotation;
    // Start is called before the first frame update

    void Update()
    {
        if(Platforms[0].transform.rotation != currentPlayerRotation)
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
        foreach (Transform platform in Platforms)
        {
            platform.transform.rotation = Quaternion.Slerp(platform.transform.rotation, currentPlayerRotation, 5f * Time.deltaTime);
        }
    }

  
}