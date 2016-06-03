using UnityEngine;


public class MusicController : MonoBehaviour {

	public AudioSource audioClip;
	public AudioClip[] clips;

	void Awake() {

		clips = Resources.LoadAll <AudioClip>("Sounds"); 
		audioClip = gameObject.GetComponent<AudioSource>();

	
	}

	public void playEatingSound() {

		audioClip.clip = clips[0];
		audioClip.Play();


	}

	public void playHelloSound() {


		audioClip.clip = clips[2];
		audioClip.Play();

	}


	public void playHitSound() {

		audioClip.clip = clips[1];
		audioClip.Play();

	}


	public void playWooshSound() {


		audioClip.clip = clips[4];
		audioClip.Play();



	}








}
