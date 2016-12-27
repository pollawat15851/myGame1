using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Text Text_Day;
	private int day;

	public int difficulty;
	public int expBonus;
	public int goldBonus;

	private bool _isDayTime = true;
	private bool _isNightTime = false;
	// Use this for initialization
	void Start () {
		StartCoroutine( countDays ());
	}
	
	// Update is called once per frame
	void Update () {
		Text_Day.text = day + "";
	}

	IEnumerator countDays(){
		while (true) {
			yield return new WaitForSeconds (30);
			if (_isDayTime) {
				_isDayTime = false;
				_isNightTime = true;
			} else if (_isNightTime){
				_isNightTime = false;
				_isDayTime = true;
				day++;
			}

		}
	}

	public bool getNightTime(){
		return _isNightTime;
	}
	public bool getDayTime(){
		return _isDayTime;
	}
	public int getDays(){
		return day;
	}

}
