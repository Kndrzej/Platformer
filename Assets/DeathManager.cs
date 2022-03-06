using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private void OnEnable()
    {
        DeathZone.OnDeath += KillPlayer;
    }
    private void OnDisable()
    {
        DeathZone.OnDeath -= KillPlayer;
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(2);
    }
}
