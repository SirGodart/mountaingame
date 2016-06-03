using UnityEngine;


public class pushText : MonoBehaviour {


	private Animator anim;

	void Awake() {
		
		anim = gameObject.GetComponent<Animator>();
		anim.speed=0;
	}


}
