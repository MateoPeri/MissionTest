using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {

	public Object[] allMissions;
	public List<Mission> activeMissions;
	public Transform missionHolder;
	public GameObject missionPrefab;
	Player player;

	private void Awake() {
		player = GetComponent<Player>();
		allMissions = Resources.LoadAll("", typeof(Mission));
	}

	private void Start() {
		DisplayMissions();
	}

	private void Update()
	{
		// We loop through each mission
		foreach (Mission mission in activeMissions)
		{
			if (mission == null)
				continue;
			// And see if it's complete
			if (mission.IsMissionCompleted())
			{
				// Then we call the mission completed method
				CompleteMission(mission);
			}
		}
	}

	public bool IsMissionActive(Mission mission)
	{
		foreach (Mission ms in activeMissions)
		{
			if (ms.Title.Contains(mission.Title))
			{
				return true;
			}
		}
		return false;
	}

	public void StartMission(Mission mission)
	{
		if (mission == null || IsMissionActive(mission))
			return;
		// We add the mission to a list of active missions
		// (Optional, but could help when displaying the mission list
		// on a menu or something)
		activeMissions.Add(mission);
		mission.active = true;
		DisplayMissions();
	}

	public void CancelMission(Mission mission)
	{
		Debug.Log("calling cancel");
		if (mission == null || !IsMissionActive(mission))
			return;
		// We remove the mission from the list
		activeMissions.Remove(mission);
		mission.active = false;
		
		DisplayMissions();
	}

	public void CompleteMission(Mission mission)
	{
		// We cancel the current mission
		CancelMission(mission);
		// We tell the player to add the moneyReward to the current money
		player.ChangeBalance(mission.moneyReward);

		// We display some info (we could also display it in a menu popup, as a text)
		Debug.Log("Mission " + mission.Title + " has been completed!");
		Debug.Log("You have received " + mission.moneyReward + "$!");
	}

	public void DisplayMissions()
	{
		foreach (Transform child in missionHolder) {
     		Destroy(child.gameObject);
		}
		
		for (int i = 0; i < activeMissions.Count; i++)
		{
			var go = Instantiate(missionPrefab);
			go.name = "Mission " + (i+1);
			go.transform.SetParent(missionHolder);
			go.transform.localScale = Vector3.one;
			go.GetComponent<MissionButton>().myMission = activeMissions[i];
		}
	}

	public void StartAllMissions()
	{
		CancelAllMissions();
		for (int i = 0; i < allMissions.Length; i++)
		{
			Mission ms = (Mission)allMissions[i];
			activeMissions.Add(ms);
		}
		DisplayMissions();
	}

	public void CancelAllMissions()
	{
		foreach (Mission ms in activeMissions.ToArray())
		{
			CancelMission(ms);
		}
	}
}
