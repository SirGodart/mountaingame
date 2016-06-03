using UnityEngine;

using System.Collections;

public class RandomText : MonoBehaviour {


	private Animator animator;
	private UnityEngine.UI.Text text;
	private int index;

	private string[] textArray = {

		"MORE FOOD PLEASE!",
		"I'M STILL HUNGRY",
		"FOOD FOOD FOOD FOOD",
		"I CAN STILL SMELL FOOD"

	};


	private int[,] fixedPositions = {

		{-250, -50},
		{250, 50},
		{-250, 100},
		{250, 150}




	};



	void Start () {

		animator = gameObject.GetComponent<Animator>();
		text = gameObject.GetComponent<UnityEngine.UI.Text>();
		text.text = textArray[textArray.Length - 1];
		animator.speed = 0;

	

	}


	private Vector3 SpawnRandomInCanvas(int x, int y) {


		return new Vector3 ( Random.Range(-x, x), Random.Range(-y, y), 0 );
	}

	private Vector3 SetFixedPositions(int index) {

		return new Vector3 (fixedPositions[index, 0], fixedPositions[index, 1], 0); 

	}


	private void Shuffle() {


	

		if (index > textArray.Length - 1) {
			index = 0;
		}

		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
			animator.Play(0);
			gameObject.transform.position = SetFixedPositions(index);
			text.text = textArray[index];
			index++;
		}

	

	}


	private IEnumerator SpawnController() {




		yield return new WaitForSeconds(0.1f);

		Shuffle();

	}

		

	void Update () {




		if (Input.GetMouseButtonDown(0)) {

			StartCoroutine(SpawnController());
			animator.speed = 1;


		}


	}
}
