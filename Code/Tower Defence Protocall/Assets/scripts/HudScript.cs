using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    public Image healthBar;
    public Text Moneybar;

    public void showHealth(float ratio)
    {
        if (ratio < 0)
        {
            ratio = 0;
        }
        healthBar.transform.localScale = new Vector3(2 * (ratio), 0.2f, 0f);
    }

    public void UpdateMoney(float money)
    {
        Moneybar.text = "Money: " + money;
    }

    public void ShowGameOver()
    {

    }

    public void ShowLevelFinished()
    {

    }
}
