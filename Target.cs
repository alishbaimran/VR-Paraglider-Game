using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(
			Random.Range(-80, 80),
			transform.position.y,
			Random.Range(-80, 80)
		);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
