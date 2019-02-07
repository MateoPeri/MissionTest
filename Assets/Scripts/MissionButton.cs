using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionButton : MonoBehaviour {

	public Mission myMission;
	public Text titleText;
	MissionManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<MissionManager>();
		titleText.text = myMission.Title;
	}

	public void Complete()
	{
		manager.CompleteMission(myMission);
	}

	public void Cancel()
	{
		manager.CancelMission(myMission);
	}
}
