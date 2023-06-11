using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp;
    public int HP { get { return hp; } private set { hp = value; OnChangeHP?.Invoke(hp); } }

    public UnityEvent<int> OnChangeHP;
    public UnityEvent OnDied;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (hp <= 0)
        {
            OnDied?.Invoke();
            GameManager.Data.CurScore++;
            GameManager.Resource.Destroy(gameObject);
            GameManager.Data.Gold += 10;
        }
    }
}
