using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public static event System.Action DoubleScore;
	public GameObject explosionPrefab;

	private AudioSource _audio;

	void Start(){
		_audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(){
		_audio.Play ();
		GameObject explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (explosion, 3);
		GetComponent<MeshRenderer> ().enabled = false;
		Destroy (this.gameObject,3);
		if (DoubleScore != null)
			DoubleScore ();
	}
}
