using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MonsterType
{
    public string name;
    public float health;
    public float damage;
    public float speed;
    GameObject gameObj;
    [Range(1,20)]
    public int ammount;
    public int difficultyNum;
}

[Serializable]
public struct Level
{
    public float maxWaveValue;
    public int level;
    public List<MonsterType> monsters;
}

[CreateAssetMenu]
public class MonsterList : ScriptableObject
{
    public List<Level> waveLevels;
    private int levelCounter;

    public bool CheckEndGame()
    {
        return (levelCounter == waveLevels.Count);
    }
    public Level GextNextLevel()
    {
        return new Level();
    }
}
