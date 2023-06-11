using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] TowerInfo[] towers;

    public TowerInfo[] Towers { get { return towers; } }

    [Serializable]
    public class TowerInfo
    {
        public Tower tower;

        public int damage;
        public int coolTime;
        public float attackRange;

        public int buildCost;
        public int sellCost;
    }
}
