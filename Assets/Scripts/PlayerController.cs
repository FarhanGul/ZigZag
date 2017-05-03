using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static event System.Action GameOver;
	public static event System.Action Score;
	public float speed;
	public AudioClip tap;
	public AudioClip death;

	private AudioSource _audio;
	private bool direction; // 1 for right and 0 for forward
	private Rigidbody rb;
	private Vector3 velocity;
	bool isGameStarted;
	bool isGameOver;
	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource> ();
		_audio.clip = tap;
		rb = GetComponent<Rigidbody> ();
		direction = true;
		UIManager.StartGame += () => {isGameStarted = true;};
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isGameOver || !isGameStarted)
			return;

		//Ray cast to see if player has ground underneath or not;
		if(!Physics.Raycast(transform.position,Vector3.down,float.MaxValue))
		{
			isGameOver = true;
			if (GameOver != null)
				GameOver ();
			rb.constraints = RigidbodyConstraints.None;
			_audio.clip = death;
			_audio.Play ();
			return;
		}
	
		
		//check for input
		if (Input.GetKeyDown ("space") || Input.GetMouseButtonDown(0) )
		{
			_audio.Play ();
			if (Score != null)
				Score ();
			//change direction
			direction = !direction;
			if (direction)
				velocity = Vector3.forward * speed;
			else
				velocity = Vector3.right * speed;
		}
			
	}
		

	void FixedUpdate(){
		rb.MovePosition (transform.position + velocity*Time.deltaTime);
	}
		
}
