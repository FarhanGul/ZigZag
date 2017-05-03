using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blink : MonoBehaviour {

	public float rate;
	Text text;

	void Start(){
		text = GetComponent<Text> ();
	}

	void Update(){
		float t = Mathf.PingPong (Time.time * rate, 1);
		text.color = Color.Lerp (Color.black, Color.clear, t);
	}
}
