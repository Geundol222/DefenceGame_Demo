using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] EnemyController enemy;
    [SerializeField] MainTower mainTower;
    [SerializeField] LayerMask enemyMask;

    private void OnTriggerEnter(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            Destroy(other.gameObject);
            mainTower.TakeDamage(1);
            GameManager.Data.HeartPoint--;
        }
    }
}
