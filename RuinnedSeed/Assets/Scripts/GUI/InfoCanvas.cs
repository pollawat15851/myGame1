using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoCanvas : MonoBehaviour {

	public GameObject target;

	public Slider HealthBar;
	public Slider EnergyBar;

	public Text AttackText;
	public Text ArmorText;
	public Text SpeedText;
	public Text GoldText;

	PlayerInfo playerInfo;
	// Use this for initialization
	void Start () {
		playerInfo = target.GetComponent<PlayerInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar.value = playerInfo.health;
		EnergyBar.value = playerInfo.energy;

		AttackText.text = playerInfo.attack+"";
		ArmorText.text = playerInfo.armor+"";
		SpeedText.text = playerInfo.speed+"";
		GoldText.text = playerInfo.gold+"";
	}
}
