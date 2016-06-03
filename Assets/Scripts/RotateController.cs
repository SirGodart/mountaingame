using UnityEngine;



public class RotateController {



	public GameObject[] allObjects;



	public void setCurrentObject() {

		allObjects = GameObject.FindGameObjectsWithTag("playobj");

	}
		
	public void InitThis() {

		for (int i = 0; i < allObjects.Length; i++) {

			allObjects[i].GetComponent<Rigidbody2D>().angularDrag = 1f;
			allObjects[i].GetComponent<Rigidbody2D>().gravityScale = 100f;
			allObjects[i].GetComponent<Rigidbody2D>().constraints = 0;

		}

	}
		
}
