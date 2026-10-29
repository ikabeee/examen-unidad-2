using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsEnemyTip(other))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private bool IsEnemyTip(Collider2D other)
    {
        return other.CompareTag("Beak") && other.transform.root != transform.root;
    }
}
