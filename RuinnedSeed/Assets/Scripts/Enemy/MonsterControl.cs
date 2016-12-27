using UnityEngine;
using System.Collections;

public class MonsterControl : MonoBehaviour {




	private GameObject target;

	MonsterInfo monsterinfo;
	Animator anime;

	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
		monsterinfo = GetComponent<MonsterInfo> ();
		target = GameObject.Find ("Crytal_Seed");
	}
	
	// Update is called once per frame
	void Update () {

		if (monsterinfo.isAttacked) {
			monsterinfo.isMoveAble = false;
			if (monsterinfo.position_attacked.x < transform.position.x) {
				transform.Translate (new Vector2 (-monsterinfo.speed * Time.deltaTime, 0));
			} else {
				monsterinfo.isAttacked = false;
				monsterinfo.isMoveAble = true;
			}
		}

		
		if (monsterinfo.isMoveAble) {
			if (monsterinfo.direction == 0) {
				transform.Translate (new Vector2 (monsterinfo.speed * Time.deltaTime, 0));
				anime.Play ("Monster0_walk_right");
			} else {
				transform.Translate (new Vector2 (-monsterinfo.speed * Time.deltaTime, 0));
				anime.Play ("Monster0_walk_left");
			}
		} else {
				transform.Translate (new Vector2 (-0.5f, -0.1f));
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject == target) {
			Destroy (gameObject);
		}

		if (col.gameObject.name == "Ground") {
			monsterinfo.isMoveAble = true;
		}
	}

	void beingAttacked(){
		
	}


}
