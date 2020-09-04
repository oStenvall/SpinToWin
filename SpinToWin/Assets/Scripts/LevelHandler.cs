using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    public Transform Platform;
    //public List<Transform> spinningPlatforms;
    Quaternion currentPlayerRotation;
    // Start is called before the first frame update

    void Update()
    {
        if(Platform.transform.rotation != currentPlayerRotation)
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
        Platform.transform.rotation = Quaternion.Slerp(Platform.transform.rotation, currentPlayerRotation, 5f * Time.deltaTime);
    }

  
}