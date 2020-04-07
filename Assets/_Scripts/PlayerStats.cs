using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public static int money;
	public int startMoney = 4000;

	public static int lives;
	public int startLives = 20;

	public static int rounds;

	private void Start() {
		money = startMoney;
		lives = startLives;
		rounds = 0;
	}

	public static void takeLive()
	{
        PlayerStats.lives--;
		StressReceiver.instance.InduceStress(0.5f);
	}
}