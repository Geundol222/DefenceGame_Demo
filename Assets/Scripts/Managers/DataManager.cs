using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    private int curScore;

    public int CurScore
    {
        get { return curScore; }
        set
        {
            OnCurrentScoreChanged?.Invoke(value);
            curScore = value;

        }
    }
    public event UnityAction<int> OnCurrentScoreChanged;

    private int heartPoint;

    public int HeartPoint
    {
        get { return heartPoint; }
        set
        {
            OnHeartPointChanged?.Invoke(value);
            heartPoint = value;
        }
    }
    public event UnityAction<int> OnHeartPointChanged;

    private int gold;

    public int Gold
    {
        get { return gold; }
        set
        {
            OnGoldChanged?.Invoke(value);
            gold = value;
        }
    }
    public event UnityAction<int> OnGoldChanged;
}
