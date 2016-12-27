using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	
	private int _health;
	private int _energy;
	private int _direction;

	private int _attack;
	private int _armor;
	private int _speed;
	private int _gold;

	private int _range;

	// Use this for initialization
	void Awake () {
		health = 100;
		energy = 100;

		attack = 15;
		armor = 0;
		speed = 10;
		gold = 0;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int health{
		get{ return _health; }
		set{ _health = value; }
	}

	public int energy{
		get{ return _energy; }
		set{ _energy = value; }
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

	public int gold{
		get{ return _gold; }
		set{ _gold = value; }
	}

	public int range{
		get{ return _range; }
		set{ _range = value; }
	}



}
