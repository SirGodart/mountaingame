using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {


	private GameObject[] clouds;

	void Awake() {

		clouds = GameObject.FindGameObjectsWithTag("cloud");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		for (int i = 0; i < clouds.Length; i++) {

			if (i % 2 == 0) {

				clouds[i].transform.position = new Vector3( Mathf.Sin( Time.time/2f ) * 25f, clouds[i].transform.position.y, clouds[i].transform.position.z);
			} else {

				clouds[i].transform.position = new Vector3( Mathf.Sin( Time.time/2f ) * -25f, clouds[i].transform.position.y, clouds[i].transform.position.z);


			}
		}
	
	}
}
