using UnityEngine;
using System.Collections;

public class RandomizeColor : MonoBehaviour {

	public Material groundMaterial;
	public Material pickupMaterial;
	public ColorSet[] colorSets;

	void Start(){
		ColorSet cs = colorSets [Random.Range (0, colorSets.Length - 1)];
		groundMaterial.color = cs.ground;
		pickupMaterial.color = cs.pickup;
	}

	[System.Serializable]
	public struct ColorSet{
		public Color ground;
		public Color pickup;
	}
}
