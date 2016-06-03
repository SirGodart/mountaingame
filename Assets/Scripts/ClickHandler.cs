using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour {

	private int objectCounter;
	private int switchInt;
	private Rigidbody2D rigidBodyObj;
	private Animation animationObj;
	private Sprite[] material;
	private RotateController controller;
	private MusicController musicController;
	private IndicatorController indicatorController;
	public GameObject musicObject;
	public GameObject indicatorObject;
	public PhysicsMaterial2D phyMat;
	private PolygonCollider2D objectCollider;
	public Animator startSprite;
	public Animator pushAnim;
	public CircleCollider2D circleCollider;

	public CanvasGroup canvasGroup;
	public BoxCollider2D topCollider;

	private bool isLoading;
	private bool isInActive;
	public GameObject go;




	void Awake() {


		musicController = musicObject.GetComponent<MusicController>();
		indicatorController = indicatorObject.GetComponent<IndicatorController>();
		controller = new RotateController();
		material = Resources.LoadAll<Sprite>("All");


	

	}


	void Start() {

		isLoading = false;
		isInActive = false;
	}

	private void CreateBlock() {

		musicController.playWooshSound();
		topCollider.enabled = false;
		go = new GameObject("Obj"+objectCounter);
		gameObjectSetup(go);
		rigidBodySetup(go);

		objectCounter++;
	

	}


	private void gameObjectSetup(GameObject go) {

		int randomScale = Random.Range(35, 50);

		go.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
		go.tag = "playobj";
		go.transform.SetParent(this.transform);
		go.transform.position = new Vector3(indicatorController.CurrentXPosition(), 320,-30f);
		go.AddComponent<SpriteRenderer>().sprite = material[Random.Range(0, material.Length)];
		go.AddComponent<Rigidbody2D>();

		objectCollider = go.AddComponent<PolygonCollider2D>();
		//objectCollider.size.Normalize();
		//objectCollider.b.(0.5f,0.5f,0);
		print ( objectCollider.points.Length);
		objectCollider.sharedMaterial = phyMat;
		for (int i = 0; i < objectCollider.points.Length; i++) {

		

			objectCollider.points[i].Set(objectCollider.points[i].x /20f, objectCollider.points[i].y/20f);


		}
	




	}

	private void rigidBodySetup(GameObject go) {

		rigidBodyObj = go.GetComponent<Rigidbody2D>();
		rigidBodyObj.mass = 1f;
		rigidBodyObj.gravityScale = 25f;
		rigidBodyObj.velocity = new Vector2(0, -800f);
		rigidBodyObj.angularDrag = 400f;
		rigidBodyObj.constraints = RigidbodyConstraints2D.FreezePositionX;
		rigidBodyObj.freezeRotation = false;

	

	}


	private IEnumerator waitForDrop() {



		if (!isLoading) {

			isLoading = true;


				yield return new WaitForSeconds(1.5f);
				controller.InitThis();
				circleCollider.enabled = false;
				startSprite.CrossFade("eatState", 0f);
				musicController.playEatingSound();


				yield return new WaitForSeconds(2f);
				
				SceneManager.LoadScene(1);
		}





	}



	private void checkInactivity() {

		float timer = Time.time;

		if (timer > 5) {


			startSprite.CrossFade("push", 0f);
			pushAnim.speed = 1;


			isInActive = true;

		}

	}

	/*
	void FixedUpdate () {

		if (controller.allObjects != null) {
				


				 
			for (int i = 1; i < controller.allObjects.Length; i++) {


				if (i % 2 == 0) { 
					controller.allObjects[i].transform.Translate(Mathf.Sin(Time.time) * new Vector3(0.015f, 0, 0));
				} else {

					controller.allObjects[i].transform.Translate(Mathf.Sin(Time.time) * new Vector3(-0.015f, 0, 0));


				}			
			}
				
		}


	}


*/



	void Update () {


		if (rigidBodyObj != null && rigidBodyObj.IsTouchingLayers() && switchInt < 2)  {

			topCollider.enabled = true;
			musicController.playHitSound();
			startSprite.CrossFade("hitState"+switchInt, 0f);
			switchInt++;

		}
		if (!isLoading) {

				if (!isInActive) {

					checkInactivity();

				}

		if (startSprite.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !startSprite.IsInTransition(0)) {
				if (Input.GetMouseButtonDown(0)) {	

								isInActive = true;	
								switchInt = 0;
								CreateBlock();
								controller.setCurrentObject();	
				} 
			} 
		} 


		if (controller.allObjects != null && !isLoading) {

						this.transform.localRotation = Quaternion.Euler(Mathf.Sin(Time.time) * new Vector3(0, 0, 4f));
						if (rigidBodyObj.IsTouching(topCollider) )  {


							StartCoroutine(waitForDrop());

						}



						for (int i = 1; i < controller.allObjects.Length; i++) {


								if (i % 2 == 0) { 
									controller.allObjects[i].transform.Translate(Mathf.Sin(Time.time) * new Vector3(0.015f, 0, 0));
								} else {

									controller.allObjects[i].transform.Translate(Mathf.Sin(Time.time) * new Vector3(-0.015f, 0, 0));


								}			
				 }


			}
			
	}
}
