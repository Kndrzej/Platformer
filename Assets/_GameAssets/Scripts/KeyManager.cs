using System.Collections;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private int deadEnemies = 0;
    private void OnEnable()
    {
        Enemy.OnHit += IncrementDeadEnemies;
    }
    private void OnDisable()
    {
        Enemy.OnHit += IncrementDeadEnemies;
    }

    private void IncrementDeadEnemies()
    {
        deadEnemies++;
    }

    private void Start()
    {
        StartCoroutine(CheckEnemiesAlive());
    }
    private IEnumerator CheckEnemiesAlive()
    {
        yield return new WaitUntil(() => deadEnemies == 3);
        key.SetActive(true);
    }
}
