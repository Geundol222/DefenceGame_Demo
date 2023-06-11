using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnCoolTime;
    [SerializeField] GameObject enemy;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCoolTime);
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
