using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : InGameUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["UpgradeButton"].onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        
    }
}
