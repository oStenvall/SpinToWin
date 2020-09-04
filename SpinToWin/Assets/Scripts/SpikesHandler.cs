using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesHandler : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerRespawner playerRespawner;

    void Awake()
    {
        playerRespawner = GameObject.FindObjectOfType<PlayerRespawner>();
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            playerRespawner.PlayerDied();
        }
    }
}
