using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryIcon : MonoBehaviour {

    public GameObject changeScene;
    //private GameObject[] children;
    public GameObject[] children;
    private GameObject[] categories;
	public float radius;
	private bool expanded;
	private bool active;
	private bool moving;
	public float speed = 4;
	private Vector3 ogPos;
	private Vector3 target;
	private Animator anim;

	// Use this for initialization
	void Awake () {
        changeScene = GameObject.FindGameObjectWithTag("Scene");

        //Find all objects with tag category
		categories = GameObject.FindGameObjectsWithTag ("Category");
		Debug.Log ("Category Count: " + categories.Length);

        //Set original position
		ogPos = transform.position;
		expanded = true;
		moving = true;

        //Set target equal to original position
		target = ogPos;

        //Get all of the Project Icons from the category
		children = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			children [i] = transform.GetChild (i).gameObject;
		}
		anim = GetComponent<Animator> ();


	}

	void OnMouseDown()
	{ 
        //Prevent from clicking if animation is playing

		if (!moving) {
//			Debug.Log ("Clicked");
			moving = true;
			active = true;
            changeScene.gameObject.SetActive(false);
			if (target == ogPos) {
                //Set target for category in the center of screen
				target = Vector3.zero;
                //Category just spins
				anim.Play ("Spin", -1, 0);

                //Set all other categories inactive 
				for (int i = 0; i < categories.Length; i++) {
					if (categories [i] != gameObject) {
						categories [i].SetActive (false);
					}
				}

			}
            //If we already clicked the category and want to go back
            else {
                //Spin back too original position
				anim.Play ("SpinDown", -1, 0);
				target = ogPos;


				Expand ();
				Invoke ("ActivateCategories", 0.3f);
                
            }
		}

	}

	void Update()
	{
        if(this.gameObject.name == "Education")
        {
            /*
            Debug.Log("Target Pos: " + target);
            Debug.Log("Original Pos: " + target);
            Debug.Log("Expanded: " + expanded);
            Debug.Log("Active: " + active);
            Debug.Log("Moving: " + moving);
            */
        }
        
        //Arent moving if our position is at the target
		if (transform.position == target) {
			moving = false;
		}
        //If we are moving then move position towards the target
		if (moving) {
			transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);
		}
        //If the target
		if (!moving && active) {
			Expand ();
		}
	}

	void Expand()
	{
		active = false;
		expanded = !expanded;

        //Iterate through the children, ProjectIcons
		for (int i = 0; i < transform.childCount; i++) {
            //Get reference to projectIcon
			ProjectIcon currentIcon = children [i].GetComponent<ProjectIcon> ();

            //If we are just looking at the categories then set currentIcons position equal to Category's
			if (expanded) {
				currentIcon.targetPos = transform.position;
				moving = true;
			}
            //After we click on a category, display the projects in a circle 
            else {
				children [i].GetComponent<ProjectIcon> ().targetPos = RandomCircle (transform.position, radius, i);

			}
			currentIcon.moving = true;
		}
	}


	Vector3 RandomCircle ( Vector3 center , float radius, float number){
		number = (number * 1.0f) / children.Length;
		float ang = number * Mathf.PI * 2;
		Vector3 pos;
		pos.x = radius * Mathf.Sin(ang);
		pos.y = radius * Mathf.Cos(ang);
		pos.z = 0;
		pos = pos + center;
		return pos;
	}

	void ActivateCategories()
	{
		for (int i = 0; i < categories.Length; i++) {
			categories [i].SetActive (true);
		}
        changeScene.gameObject.SetActive(true);
    }
}
