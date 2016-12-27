using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {
	//public GameObject SystemControl;
	public GameObject[] monsters;
	public int direction;

	private int random_monster;


	GameControl gc;
	// Use this for initialization
	void Start () {
		//gc = SystemControl.GetComponent<GameControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(gc.getNightTime()){
			for (int i = 0; i < gc.getDays(); i++) {
				random_monster = Random.Range (0, monsters.Length);
				GameObject monster = Instantiate (monsters [random_monster], transform.position, Quaternion.identity) as GameObject;
				MonsterInfo mi = monster.GetComponent<MonsterInfo> ();
				mi.direction = direction;
			}
		}
	*/
		if(Input.GetKeyDown(KeyCode.Alpha0))
		for (int i = 0; i < 1; i++) {
			random_monster = Random.Range (0, monsters.Length);
			GameObject monster = Instantiate (monsters [random_monster], transform.position, Quaternion.identity) as GameObject;
			MonsterInfo mi = monster.GetComponent<MonsterInfo> ();
			mi.direction = direction;
		}
	
	}



}
