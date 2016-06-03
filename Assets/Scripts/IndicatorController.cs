using UnityEngine;
using System.Collections;

public class IndicatorController : MonoBehaviour {


	public float speed;
	public float length;

	// Use this for initialization
	void Start () {
	
	}


	public float CurrentXPosition() {

		return gameObject.transform.position.x;


	}

	private void moveOnX() {
		
		gameObject.transform.position = new Vector3( Mathf.Sin( Time.time* speed ) * length, transform.position.y, transform.position.z);

	}


	void Update () {

		moveOnX();
	
	}
}
