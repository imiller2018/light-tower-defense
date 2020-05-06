using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Sprite finishedLevel;
    public Sprite Gameover;
    public Image FinalImage;
    public Text scoreText;
    public Button backButton;
    public Text backText;
    public GameObject scoreBoard;
    public GameObject UI;
    public float maxHealth;
    public float remainingHealth;
    public MonsterList monsterWaveList;
    public spawners spawnLocations;

    public int money = 0;

    public float waitTimer;
    public float startTimer;
    public float waveWaitTimer;

    private bool endgame = false;
    private bool levelfinished = true;
    private bool noMoreSpawning = false;
    private float difficultyCounter = 0;
    private float maxDifficulty;
    public float monstercount = 0;
    private List<GameObject> monsterList;
    public bool hold = false;
    private int waveNum = -1;

    public bool Buy(int m)
    {
        if (money >= m)
        {
            money -= m;
            UI.GetComponent<HudScript>().UpdateMoney(money);
            return true;
        }
        return false;
    }

    public void takedamage(float damage)
    {
        remainingHealth -= damage;
        UI.GetComponent<HudScript>().showHealth(remainingHealth / maxHealth);
        if (remainingHealth<=0 && !endgame){
            endgame = true;
            EndGame();
        }
    }

    public void addHealth(float heal)
    {
        remainingHealth += heal;
        UI.GetComponent<HudScript>().showHealth(remainingHealth / maxHealth);
    }

    public void EndGame()
    {
        scoreBoard.GetComponent<ScoreScript>().addCastle_health((int)remainingHealth);
        scoreBoard.GetComponent<ScoreScript>().addMoney(money);
        FinalImage.sprite = Gameover;
        scoreText.text = "" + scoreBoard.GetComponent<ScoreScript>().calculatescore();
        scoreText.transform.localPosition = new Vector3(-130, 176, 0);
        backButton.transform.localPosition = new Vector3(275, 235, 0);
        FinalImage.enabled = true;
        scoreText.enabled = true;
        backButton.enabled = true;
        backButton.image.enabled = true;
        backText.enabled = true;
    }

    void Update()
    {
        if (!hold){
            if (!noMoreSpawning)
            {
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
            else
            {
                if(monstercount == 0 && !endgame)
                {
                    endgame = true;
                    FinishedLevel();
                }
            }
        }
    }

    public void monsterDied(float val, int m)
    {
        monstercount--;
        difficultyCounter -= val;
        money += m;
        hold = false;
        scoreBoard.GetComponent<ScoreScript>().addGameScore(200);
        UI.GetComponent<HudScript>().UpdateMoney(money);
    }

    public void StartNextWave()
    {
        waveNum++;
        if (monsterWaveList.CheckEndGame(waveNum))
        {
            noMoreSpawning = true;
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
                int offset = UnityEngine.Random.Range(-5, 5);
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
                monstercount++;
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
        scoreBoard.GetComponent<ScoreScript>().addCastle_health((int)remainingHealth);
        scoreBoard.GetComponent<ScoreScript>().addMoney(money);
        scoreBoard.GetComponent<ScoreScript>().addGameScore(10000);
        FinalImage.sprite = finishedLevel;
        scoreText.text = "" + scoreBoard.GetComponent<ScoreScript>().calculatescore();
        scoreText.transform.localPosition = new Vector3(135, -47, 0);
        FinalImage.enabled = true;
        scoreText.enabled = true;
        backButton.image.enabled = true;
        backButton.enabled = true;
        backText.enabled = true;
    }
}
