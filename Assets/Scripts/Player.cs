using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float money;
	public Text moneyText;

	public void ChangeBalance(float amount)
	{
		money += amount;
		moneyText.text = money.ToString() + "$";
	}
}
