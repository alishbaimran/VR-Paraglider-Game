using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 2.25f;
	public float fallingForce = 3;
	public float restartTimer = 3f;

	public TextMesh infoText;

	private bool isGameOver;
	private bool won;

	// Use this for initialization
	void Start () {
		infoText.text = "Land on the rings!";
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver == false) {
			Vector3 direction = new Vector3 (
                transform.forward.x,
                -fallingForce,
                transform.forward.z
            );

			transform.position += direction.normalized * speed * Time.deltaTime;
		} else {
			restartTimer -= Time.deltaTime;

			if (restartTimer < 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			} else {
				if (won == true) {
					infoText.text = "Great job, you win!";
					infoText.text += "\nGame restarts in " + Mathf.Ceil (restartTimer);
				} else {
					infoText.text = "Try again!";
					infoText.text += "\nGame restarts in " + Mathf.Ceil (restartTimer);
				}
			}
		}
	}

	void OnTriggerEnter (Collider otherCollider) {
		if (otherCollider.tag == "Target") {
			won = true;
		} else {
			won = false;
		}

		isGameOver = true;
	}
}
