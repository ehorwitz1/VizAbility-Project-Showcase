using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour {

	void OnMouseDown()
	{
		Application.Quit ();
		Debug.Log ("I would have quit.");
	}
}
