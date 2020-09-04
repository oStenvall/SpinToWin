using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{

    // Start is called before the first frame update

    public Transform respwanPoint;
    public Transform playerCamera;
    public Transform player;
    PlayerMovement playerMovement;

    private bool alive;
    void Start()
    {
        bool alive = true;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            player.transform.position = respwanPoint.transform.position;
            playerCamera.transform.position = respwanPoint.transform.position;
            playerMovement.ResetRotations();
            alive = true;
        }
    }

    public void PlayerDied()
    {
        alive = false;
    }


}
