using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerAdapter : MonoBehaviour
{
    public bool playable;

    public VideoClip beeClip;
    public VideoClip greenWaveClip;
    public VideoClip selfHarmClip;
    public VideoClip virtualHealthyClip;

    public VideoPlayer player;
    public GameObject videoQuad;

    // Start is called before the first frame update
    private void Awake()
    {
        //video.Pause();

    }
    void Start()
    {
        //video.Pause();
        //playable = false;
        player = GetComponent<VideoPlayer>();

        beeClip = Resources.Load<VideoClip>("BeeClip");
        greenWaveClip = Resources.Load<VideoClip>("GreenWaveClip");
        selfHarmClip = Resources.Load<VideoClip>("SelfHarm");
        virtualHealthyClip = Resources.Load<VideoClip>("VirtualHealthy");


        videoQuad = GameObject.Find("VideoQuad");

        videoQuad.SetActive(false);
    }

    private void OnEnable()
    {
        //playable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playable)
        {

            player.Play();
            videoQuad.SetActive(true);

        }
        else
        {
            player.Stop();
            videoQuad.SetActive(false);
        }
        
    }


    public void PlayVideo(string videoID)
    {
        switch (videoID)
        {
            case "bee":
                player.clip = beeClip;
                break;
            case "green":
                player.clip = greenWaveClip;
                break;
            case "selfHarm":
                player.clip = selfHarmClip;
                break;
            case "virtualHealthy":
                player.clip = virtualHealthyClip;
                break;
            default:
                player.clip = beeClip;
                break;
        }
    }


    void OnMouseDown()
    {

    }

}
