using UnityEngine;
using System.Collections;

public class materialAnimator : MonoBehaviour {

	void Start () {
	
	}
	
	//
	void Update () {


		gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(Time.time/2.0f,0));

	
	}
}
