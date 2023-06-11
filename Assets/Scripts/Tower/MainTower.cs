using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainTower : MonoBehaviour
{
    [SerializeField] private int hp;
    public int HP { get { return hp; } private set { hp = value; OnChangeHP?.Invoke(hp); } }

    public UnityEvent<int> OnChangeHP;
    public UnityEvent OnDestroyed;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (hp <= 0)
        {
            OnDestroyed?.Invoke();
        }
    }
}
