using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public LayerMask mask;

    public UnityEvent<EnemyController> OnEnemyInRange;
    public UnityEvent<EnemyController> OnEnemyOutRange;

    private void OnTriggerEnter(Collider other)
    {
        if (mask.IsContain(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            enemy.OnDied.AddListener(() => { OnEnemyOutRange?.Invoke(enemy); });
            OnEnemyInRange?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mask.IsContain(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            
            OnEnemyOutRange?.Invoke(enemy);
        }
    }
}
