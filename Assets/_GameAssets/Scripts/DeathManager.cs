using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private void OnEnable()
    {
        DeathZone.OnDeath += KillPlayer;
        Enemy.OnDeath += KillPlayer;
    }
    private void OnDisable()
    {
        DeathZone.OnDeath -= KillPlayer;
        Enemy.OnDeath += KillPlayer;
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(2);
    }
}
