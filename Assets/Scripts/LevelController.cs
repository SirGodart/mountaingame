using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public GameObject loader;
	private bool isLoading = false;


	private IEnumerator LoadnNext() {

		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(1);


	}


	void Update() {

		if (!isLoading) {

			StartCoroutine(LoadnNext());

		}


		loader.transform.Rotate(0,0, Time.timeScale*-3.0f);




	}


}
