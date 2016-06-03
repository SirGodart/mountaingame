using UnityEngine;


public class BgController : MonoBehaviour {



	void Update () {

		transform.Translate(Mathf.Sin(Time.time) / 10f * Vector3.left);
	
	}
}
