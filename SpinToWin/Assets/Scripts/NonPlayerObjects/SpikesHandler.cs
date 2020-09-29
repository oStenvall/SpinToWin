using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesHandler : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerDied(col.gameObject);
        }
    }

    void PlayerDied(GameObject Player)
    {
        Player.GetComponent<PlayerMovement>().ResetRotations();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
