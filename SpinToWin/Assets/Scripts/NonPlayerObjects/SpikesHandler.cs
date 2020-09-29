using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesHandler : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
