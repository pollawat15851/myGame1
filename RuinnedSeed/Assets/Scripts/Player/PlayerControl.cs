using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject ray_right;
	public GameObject ray_left;

	public Transform[] ignore_list;

	private float range;

	private bool _isMoveable = true;
	private bool _isAttackable = true;
	private bool _isInStunned = false;

	Animator anim;

	Ray2D ray;
	RaycastHit2D hit;

	Rigidbody2D rb;
	PlayerInfo playerinfo;
	MonsterInfo monsterinfo;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		playerinfo = GetComponent<PlayerInfo> ();
	
		for (int i = 0; i < ignore_list.Length; i++) {
			Physics2D.IgnoreCollision (ignore_list [i].GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}

		range = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Anime_playerAttackLeft") && !anim.GetCurrentAnimatorStateInfo (0).IsName ("Anime_playerAttack")) {
			_isMoveable = true;
			_isAttackable = true;
		}

		Debug.DrawRay (ray_left.transform.position, Vector2.left*range);
		Debug.DrawRay (ray_right.transform.position, Vector2.right*range);
	
		if (_isMoveable) {
			Keyboard_Movement();
		}
		if (_isAttackable) {
			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				doAttack ();
				if (playerinfo.direction == 0) {
					anim.Play ("Anime_playerAttack");
				} else if (playerinfo.direction == 1) {
					anim.Play ("Anime_playerAttackLeft");
				}
				_isMoveable = false;
				_isAttackable = false;
				playerinfo.energy--;
			}
		}
	}
		

	void OnCollisionEnter2D(Collision2D col){}

	void statsUpdate(){
		if (_isInStunned) {
			_isMoveable = false;
			_isAttackable = false;
		}
	}

	void Keyboard_Movement(){
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (new Vector2 (-playerinfo.speed * Time.deltaTime, 0));
			playerinfo.direction = 1;
			anim.Play ("Anime_playerRunLeft");
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			anim.Play ("Anime_playerIdleLeft");
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (new Vector2 (playerinfo.speed * Time.deltaTime, 0));
			playerinfo.direction = 0;
			anim.Play ("Anime_playerRun");
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			anim.Play ("Anime_playerIdle");
		}

	}

	void doAttack(){
		
		if (playerinfo.direction == 0) {
			hit = Physics2D.Raycast (ray_right.transform.position, Vector2.right,range);// new Vector2(ray_right.transform.position.x+range,ray_right.transform.position.y));
		} else if (playerinfo.direction == 1) {
			hit = Physics2D.Raycast(ray_left.transform.position,Vector2.left,range);
		}


		if (hit.collider != null) {
			Debug.Log (hit.collider.gameObject);
			if (hit.collider.gameObject.tag == "Monster") {
				hit.collider.transform.Translate (new Vector2 (-1, 2));
				monsterinfo = hit.collider.gameObject.GetComponent<MonsterInfo> ();
				monsterinfo.isMoveAble = false;
				monsterinfo.health -= 1;

			}
		}

	}
	void doJump(){
		
	}

}
