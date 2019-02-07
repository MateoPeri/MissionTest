using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KillMission", menuName = "killMission")]
public class KillMission : Mission
{
	// The enemy that we have to kill in order to complete the mission
	public GameObject enemyToKill;
	// How many
	public int requiredKillCount;
	// How many have we killed so far
	public int currentKillCount;

	// You would call this method from the attack script
	// or player controller, or whatever manages your player
	// every time you kill an enemy
	public void EnemyKilled(GameObject obj)
	{
		// I'm comparing names, you could go for a more complex system,
		// like an enum called EnemyType or whatever
		if (obj.name.Contains(enemyToKill.name))
		{
			currentKillCount++;
		}
	}

	public override bool IsMissionCompleted()
	{
		return currentKillCount >= requiredKillCount;
	}
}