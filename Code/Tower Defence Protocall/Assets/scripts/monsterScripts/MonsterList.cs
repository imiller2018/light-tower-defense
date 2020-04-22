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
    public int money;
    public GameObject MonsterGO;
}

[Serializable]
public struct Level
{
    public float maxWaveValue;
    public List<MonsterType> monsters;
}

[CreateAssetMenu]
public class MonsterList : ScriptableObject
{
    public List<Level> waveLevels;

    public bool CheckEndGame(int levelCounter)
    {
        return (levelCounter == waveLevels.Count);
    }

    public List<GameObject> GetNextLevel(int levelCounter)
    {
        Level newLevel = new Level();
        List<GameObject> monsterList = new List<GameObject>();
        newLevel.maxWaveValue = waveLevels[levelCounter].maxWaveValue;
        foreach (MonsterType MonsterT in waveLevels[levelCounter].monsters)
        {
            for (int i = 0; i < MonsterT.ammount; i++)
            {
                GameObject newMonster = MonsterT.MonsterGO;
                //newMonster.GetComponent<Monster>().SetStats(MonsterT.health, MonsterT.damage, MonsterT.money, MonsterT.speed, MonsterT.difficultyNum);
                monsterList.Add(MonsterT.MonsterGO);
            }
        }
        return monsterList;
    }

    public float getMaxDiff(int levelCounter)
    {
        return waveLevels[levelCounter].maxWaveValue;
    }
}
