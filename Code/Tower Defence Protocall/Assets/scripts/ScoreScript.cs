using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreScript:MonoBehaviour
{
    private int game_score = 0;
    private int castle_health = 0;
    private int moneyscore = 0;

    // Update is called once per frame
    public int calculatescore()
    {
        return game_score + castle_health*10 + moneyscore;
    }

    public void addGameScore(int score)
    {
        game_score += score;
    }

    public void addCastle_health(int health)
    {
        castle_health += health;
    }

    public void addMoney(int money)
    {
        money += money;
    }
}
