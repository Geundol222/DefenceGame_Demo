using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    protected List<EnemyController> enemyList;
    protected TowerData data;
    public TowerData Data { get { return data; } }

    protected int towerIndex = 0;
    public int TowerIndex { get { return towerIndex; } set { towerIndex = value; OnTowerIndexChanged?.Invoke(); } }
    public UnityEvent OnTowerIndexChanged;

    protected virtual void Awake()
    {
        enemyList = new List<EnemyController>();
    }

    public void AddEnemy(EnemyController enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemyList.Remove(enemy);
    }
}