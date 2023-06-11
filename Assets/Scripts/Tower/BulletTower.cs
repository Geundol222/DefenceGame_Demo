using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Tower
{
    [SerializeField] Transform turret;
    [SerializeField] Transform firePoint;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/BulletTowerData");
    }

    private void OnEnable()
    {
        StartCoroutine(LookRoutine());
        StartCoroutine(AttackRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while(true)
        {
            if (enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.Towers[0].coolTime);
            }
            else
            {
                yield return null;
            }            
        }
    }

    public void Attack(EnemyController enemy)
    {
        Bullet bullet = GameManager.Resource.Instantiate<Bullet>("Prefabs/Bullet", firePoint.position, firePoint.rotation);
        bullet.SetTarget(enemy);
        bullet.SetDamage(data.Towers[0].damage);
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if (enemyList.Count > 0)
            {
                turret.LookAt(enemyList[0].transform.position);
            }

            yield return null;
        }
    }
}
