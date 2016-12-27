using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	private GameObject target;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target) {
			transform.position = new Vector3 (target.transform.position.x, transform.position.y, -10);
		}
	}
}
