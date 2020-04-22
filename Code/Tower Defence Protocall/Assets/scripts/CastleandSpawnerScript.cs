using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct spawners
{
    public GameObject North;
    public GameObject South;
    public GameObject West;
    public GameObject East;
}

public class CastleandSpawnerScript : MonoBehaviour
{
    public GameObject UI;
    public float maxHealth;
    public float remainingHealth;
    public MonsterList monsterWaveList;
    public spawners spawnLocations;

    private float money = 0;

    public float waitTimer;
    public float startTimer;
    public float waveWaitTimer;

    private bool levelfinished = true;
    private float difficultyCounter = 0;
    private float maxDifficulty;
    private List<GameObject> monsterList;
    public bool hold = false;
    private int waveNum = -1;
    public void takedamage(float damage)
    {
        remainingHealth -= damage;
        UI.GetComponent<HudScript>().showHealth(remainingHealth / maxHealth);
        if (remainingHealth<=0){
            EndGame();
        }
    }

    public void addHealth(float heal)
    {
        remainingHealth += heal;
    }

    public void EndGame()
    {

    }

    void Update()
    {
        if (!hold){
            if (startTimer <= 0)
            {
                if (levelfinished)
                {
                    startTimer = waitTimer;
                    levelfinished = false;
                    StartNextWave();
                }
                else
                {
                    summonAnotherMonster();
                    startTimer = waitTimer;
                }
            }
            else
            {
                startTimer -= Time.deltaTime;
            }
        }
    }

    public void monsterDied(float val, float m)
    {
        difficultyCounter -= val;
        money += m;
        hold = false;
        UI.GetComponent<HudScript>().UpdateMoney(money);
    }

    public void StartNextWave()
    {
        waveNum++;
        if (monsterWaveList.CheckEndGame(waveNum))
        {
            FinishedLevel();
        }
        else
        {
            monsterList = monsterWaveList.GetNextLevel(waveNum);
            maxDifficulty = monsterWaveList.getMaxDiff(waveNum);
        }
    }

    public void summonAnotherMonster()
    {
        if (monsterList.Count == 0)
        {
            levelfinished = true;
            startTimer = waveWaitTimer;
        }
        else
        {
            int index = UnityEngine.Random.Range(0, monsterList.Count);
            float diffval = monsterList[index].GetComponent<Monster>().getDiffVal();
            if (diffval + difficultyCounter <= maxDifficulty)
            {
                Debug.Log("summoning");
                difficultyCounter += diffval;
                int rotation = UnityEngine.Random.Range(0, 4);
                int offset = UnityEngine.Random.Range(-7, 7);
                Vector3 newposition;
                Quaternion newRot;
                switch (rotation)
                {
                    default:
                        newposition = spawnLocations.North.transform.position;
                        newposition = new Vector3(newposition.x + offset, newposition.y, newposition.z);
                        Debug.Log("North");
                        newRot = spawnLocations.North.transform.rotation;
                        break;
                    case 1:
                        newposition = spawnLocations.South.transform.position;
                        newposition = new Vector3(newposition.x + offset, newposition.y, newposition.z);
                        Debug.Log("South");
                        newRot = spawnLocations.South.transform.rotation;
                        break;
                    case 2:
                        newposition = spawnLocations.East.transform.position;
                        newposition = new Vector3(newposition.x, newposition.y, newposition.z + offset);
                        Debug.Log("East");
                        newRot = spawnLocations.East.transform.rotation;
                        break;
                    case 3:
                        newposition = spawnLocations.West.transform.position;
                        newposition = new Vector3(newposition.x, newposition.y, newposition.z + offset);
                        Debug.Log("West");
                        newRot = spawnLocations.West.transform.rotation;
                        break;
                }
                GameObject newObject = Instantiate(monsterList[index], newposition, newRot) as GameObject;
                newObject.GetComponent<Monster>().SetCastle(this.gameObject);
                newObject.GetComponent<Monster>().Move();
                newObject.GetComponent<Monster>().HealthBarRotation(new Vector3(newposition.x, 100, newposition.z - 10));
                monsterList.RemoveAt(index);
            }
            else
                hold = true;
        }
    }

    private void FinishedLevel()
    {
        Debug.Log("level finished");
    }
}
