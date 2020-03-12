using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreen : MonoBehaviour {

	private Camera cam;
	public float offset;

    public string videoID;

    public VideoPlayerAdapter videoAdapter;


    private bool videoPlaying;

    private Vector3 targetScale;
	private Vector3 targetPos;
	private float height;
	private bool scaling;
	public float speed = 5;
	private Vector3 ogScale;

    private Rect bounds;

	//public Texture texture;

	// Use this for initialization
	void Start () {
		//GetComponent<Renderer> ().material.mainTexture = texture;
        //Get original scale
		ogScale = transform.localScale;
		cam = Camera.main;

        //Get height for camera rendering
		height = Mathf.Tan (cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * offset * 2f;
		targetScale = new Vector3 (height * cam.aspect, height, 1);
		targetPos = cam.transform.position + cam.transform.forward * offset * 2;

        //Find the video player adapter
        videoAdapter = GameObject.Find("VideoPlayer").GetComponent<VideoPlayerAdapter>();
        videoPlaying = false;

        //This sets the bounds for the back button
        bounds = new Rect(Screen.width - (Screen.width / 20), Screen.height - (Screen.height / 15), Screen.width, Screen.height / 15);

    }

	void OnEnable()
	{
        //The second the script is enabled start scaling image. 
		scaling = true;
    }

	
	// Update is called once per frame
	void Update () {

        //Check to see if the user clicked in the back button bounds
        if (Input.GetMouseButtonDown(0) && bounds.Contains(Input.mousePosition))
        {
            videoAdapter.playable = false;
            videoPlaying = false;
            closeScreen();
        }



        //If we are at the target scale and position do nothing
        if (transform.localScale == targetScale && transform.position == targetPos) {
			scaling = false;
		}
        //If we are scaling lerp the position and scale to calculated values 
		if (scaling) {
			transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime * speed);
			transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * speed);
		}
	}

	void OnMouseDown()
	{
        //If there is no videoID then there is no video to play
        //just close the screen when clicked
        if(string.IsNullOrEmpty(videoID))
        {
            closeScreen();
        }
        else
        {
            if (videoPlaying == false)
            {
                videoAdapter.PlayVideo(videoID);
                videoAdapter.playable = true;
                videoPlaying = true;
            }
            else
            {
                videoAdapter.playable = false;
                videoPlaying = false;
            }
        }


        

        /*
        //Put position at origin
		transform.localPosition = Vector3.zero;
		//Set to original scale
        transform.localScale = ogScale;
        //Turn off game object
		gameObject.SetActive (false);
        */
	}

    public void closeScreen()
    {
        //Put position at origin
        transform.localPosition = Vector3.zero;
        //Set to original scale
        transform.localScale = ogScale;
        //Turn off game object
        gameObject.SetActive(false);
    }


}
