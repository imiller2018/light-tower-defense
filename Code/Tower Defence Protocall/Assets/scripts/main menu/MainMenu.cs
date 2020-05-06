using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
   public void BtnNewScene()
	{
		SceneManager.LoadScene("Scene 1");
		Console.Write("Test");
	}
}
