using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectIcon : MonoBehaviour {

	public Vector3 targetPos;
	public bool moving;
	public float speed;
	private Renderer rend;
	private GameObject info;

	// Use this for initialization
	void OnEnable() {
		rend = GetComponent<Renderer> ();
        //Get reference to projectInfo Image
		info = transform.GetChild(0).gameObject;
		info.SetActive (false);

        //Set target position to zero
		targetPos = Vector3.zero;

        //Do not render it yet
		rend.enabled = false;

		//GetComponent<Animator> ().Play ("Appear", -1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //Stop moving if we are at the target position
		if (transform.localPosition == targetPos) {
			moving = false;
		}

        //If we can move, then move towards the target position
		if (moving) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetPos, Time.deltaTime * speed);
		}

        //If the target position is at zero then do not render the projectIcon
		if (targetPos == (Vector3.zero)) {
			if (rend.enabled == true && moving == false) {
				rend.enabled = false;
			}
		}
        //If the target position is not zero, we are going to move and render the icon
        else {
			if (rend.enabled == false) {
				rend.enabled = true;
			}
		}
	
			
	}

	void OnMouseDown()
	{
        //Set the project info image on 
		info.SetActive (true);
	}
}
