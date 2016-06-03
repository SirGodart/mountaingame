using UnityEngine;
using System.Collections;

public class BlocksLeftText : MonoBehaviour {


	public UnityEngine.UI.Text mytext;
	private int counter = 5;



	void Awake() {

		mytext = gameObject.GetComponent<UnityEngine.UI.Text>();

	}


	void Start () {

		mytext.text = counter.ToString() + " objects left";
	
	}
	

	void Update () {

		if (counter > 0) {  

					if (Input.GetMouseButtonDown(0)) {


						counter--;
						mytext.text = counter.ToString() + " objects left";
					}


		}
	
	}
}
