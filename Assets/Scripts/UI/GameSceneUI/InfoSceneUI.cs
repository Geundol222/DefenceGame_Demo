using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSceneUI : GameSceneUI
{
    protected override void Awake()
    {
        base.Awake();

        texts["HeartText"].text = "10";
        GameManager.Data.HeartPoint = 10;
        texts["CoinText"].text = "100";
        GameManager.Data.Gold = 100;
    }
}
