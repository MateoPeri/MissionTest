using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RetrieveMission", menuName = "RetrieveMission")]
public class RetrieveMission : Mission {

	// Replace this with a gameObject or whatever
	// This is the item needed to complete the mission
	public string itemToRetrieve;
	// How many
	public int requiredItemCount;
	// How many have we retrieved so far
	public int currentItemCount;

	// You would call this from your inventory manager
	// or whatever scripts manages your items
	public void RetrieveItem(string item)
	{
		// I'm comparing strings, you could go for a more complex system,
		// like an inventory system
		if (item.Contains(itemToRetrieve))
		{
			currentItemCount++;
		}
	}

	public override bool IsMissionCompleted()
	{
		return currentItemCount >= requiredItemCount;
	}
}
