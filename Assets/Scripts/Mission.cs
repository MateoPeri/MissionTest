using System;
using UnityEngine;

public class Mission : ScriptableObject
{
	public string Title;
	[TextArea]
	public string Description;
	public float moneyReward;

	public bool active = false;

	public Mission(string title, string description, float moneyReward)
	{
		this.Title = title;
		this.Description = description;
		this.moneyReward = moneyReward;
	}

	public Mission()
	{
		this.Title = "";
		this.Description = "";
		this.moneyReward = 0f;
	}

	// We make a method to check if the mission is completed
	public virtual bool IsMissionCompleted()
	{
		return false;
	}
}
