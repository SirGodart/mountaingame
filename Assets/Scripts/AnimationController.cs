using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {



	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Sprite material;
	public GameObject musicObject;

	private MusicController musicController;

	private IEnumerator StartSprite() {

		yield return new WaitForSeconds(1.0f);
		animator.speed = 2;
		musicController.playHelloSound();
	}


	void Awake() {

		musicController = musicObject.GetComponent<MusicController>();
		animator = gameObject.GetComponent<Animator>();
		animator.speed = 0;



	}
	void Start () {
			

			StartCoroutine(StartSprite());

	}




	

}
