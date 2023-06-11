using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainBuildingHP : MonoBehaviour
{
    [SerializeField] MainTower mainTower;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = mainTower.HP;
        slider.value = mainTower.HP;
        mainTower.OnChangeHP.AddListener((hp) => { slider.value = hp; });
        mainTower.OnDestroyed.AddListener
        (() => 
        {
            GameManager.Resource.Destroy(gameObject);
            GameManager.UI.ShowPopUpUI<GameOverUI>("UI/GameOverUI");
        }
        );
    }

}
