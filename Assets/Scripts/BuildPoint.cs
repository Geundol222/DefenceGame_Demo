using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color select;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = select;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            BuildSelectUI buildSelectUI = GameManager.UI.ShowInGameUI<BuildSelectUI>("UI/BuildSelectUI");
            buildSelectUI.SetTarget(transform);
            buildSelectUI.SetOffset(new Vector2(0, 200f));
            buildSelectUI.buildPoint = this;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void BuildTower(TowerData data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.Towers[0].tower, transform.position, Quaternion.Euler(0, 180, 0));
    }
}
