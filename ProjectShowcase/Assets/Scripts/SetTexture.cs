using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTexture : MonoBehaviour {

	public Texture texture;
	public Color color;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.SetTexture ("_Texture", texture);// = texture;
		GetComponent<Renderer> ().material.SetColor ("_OverlayColor", color);
	}

}
