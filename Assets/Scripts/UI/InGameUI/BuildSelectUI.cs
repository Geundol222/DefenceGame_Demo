using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSelectUI : InGameUI
{
    public BuildPoint buildPoint;

    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<BuildSelectUI>(this); });
        buttons["CanonButton"].onClick.AddListener(BuildCanonTower);
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/BulletTowerData");

        if (GameManager.Data.Gold > canonTowerData.Towers[0].buildCost)
        {
            GameManager.Data.Gold -= canonTowerData.Towers[0].buildCost;
            buildPoint.BuildTower(canonTowerData);
        }
        else
        {
            GameManager.UI.ShowInGameUI<NoMoneyText>("UI/NoMoneyText");
            return;
        }            
    }
}
