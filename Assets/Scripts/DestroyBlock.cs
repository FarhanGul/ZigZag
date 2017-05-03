using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			StartCoroutine (Kill());
	}

	public IEnumerator Kill()
	{
		yield return new WaitForSeconds (0.5f);
		transform.parent.gameObject.AddComponent<Rigidbody> ();
		transform.parent.gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, -1.0f, 0.0f);
		Destroy (transform.parent.gameObject, 2);
		ProceduralGeneration.n--;
	}
}
