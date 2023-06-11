using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private TrailRenderer trail;
    private EnemyController enemy;
    private Vector3 targetPoint;
    private int damage;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(BulletRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator BulletRoutine()
    {
        while (true)
        {
            if (enemy != null)
                targetPoint = enemy.transform.position;

            transform.LookAt(targetPoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
            {
                if (enemy != null)
                    Attack(enemy);
                GameManager.Resource.Destroy(gameObject);
                trail.Clear();
                yield break;
            }
            yield return null;
        }        
    }

    public void Attack(EnemyController enemy)
    {
        enemy.TakeDamage(damage);
    }
}
