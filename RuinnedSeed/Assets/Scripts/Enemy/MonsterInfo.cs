using UnityEngine;
using System.Collections;

public class MonsterInfo : MonoBehaviour {

	private int _health;
	private int _direction;

	private int _attack;
	private int _armor;
	private int _speed;

	private float colorR; // color red
	private float colorG; // color green
	private float colorB; // color blue
	private float myAlpha; // color alpha

	private bool isDead;
	private bool _isMoveable = true;

	private bool _isAttacked;
	private Vector2 pos_attacked;


	SpriteRenderer sprite_render;
	// Use this for initialization
	void Start () {
		sprite_render = GetComponent<SpriteRenderer> ();
		colorR = sprite_render.color.r;
		colorG = sprite_render.color.g;
		colorB = sprite_render.color.b;
		myAlpha = sprite_render.color.a;
		health = 20;
		attack = 10;
		armor = 5;
		speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
		//check dead
		if (health < 1) {
			doDead ();
		}

		if (isDead) {
			myAlpha -= 0.01f;
			sprite_render.color = new Color (colorR,colorG,colorB,myAlpha);
			if (myAlpha < 0.1f) {
				Destroy (gameObject);
			}
		}

	

	}

	void doDead(){
		Destroy (GetComponent<CircleCollider2D>());
		Destroy (GetComponent<MonsterControl>());
		Destroy (GetComponent<Rigidbody2D> ());
		Destroy (GetComponent<Animator> ());
		isDead = true;

	}

	public int health{
		get{ return _health; }
		set{ _health = value; }
	}
	public int direction{
		get{ return _direction; }
		set{ _direction = value; }
	}
	public int attack{
		get{ return _attack; }
		set{ _attack = value; }
	}
	public int armor{
		get{ return _armor; }
		set{ _armor = value; }
	}
	public int speed{
		get{ return _speed; }
		set{ _speed = value; }
	}

	public bool isMoveAble{
		get{return _isMoveable;}
		set{ _isMoveable = value; }
	}

	public bool isAttacked{
		get{ return _isAttacked; }
		set{ _isAttacked = value; }
	}

	public Vector2 position_attacked{
		get{ return pos_attacked; }
		set{ pos_attacked = value; }
	}

}
