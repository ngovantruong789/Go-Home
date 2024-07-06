using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : TruongMonoBehaviour
{
    private static GameLevelManager instance;
    public static GameLevelManager Instance => instance;

    [SerializeField] protected int level = 1;
    [SerializeField] protected int maxLevel = 3;

    protected override void Awake()
    {
        base.Awake();
        if(GameLevelManager.instance == null)
        {
            GameLevelManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void LevelUp()
    {
        if (level >= maxLevel) return;
        level++;
    }

    public int GetLevel()
    {
        return level;
    }
}
