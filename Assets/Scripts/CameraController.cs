using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController playerController;
	public Transform target;
	private float speed;
	private Vector3 direction;
	bool isGameStarted;
	bool isGameOver;
	// Use this for initialization
	void Start () {
		direction = new Vector3 (1.0f, 0.0f, 1.0f);
		direction.Normalize ();
		UIManager.StartGame += () => {isGameStarted = true;};
		PlayerController.GameOver+= () => {isGameOver = true;};
		speed = playerController.speed * Mathf.Cos (45.0f * Mathf.Deg2Rad);
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameStarted && !isGameOver)
			transform.Translate (direction * speed * Time.deltaTime,Space.World);
	}
}
