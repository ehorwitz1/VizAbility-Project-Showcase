using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuManager : MonoBehaviour
{

    public Animator anim;

    public GameObject subtitle;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayAnim", .25f);
        Invoke("EnableSubtitle", 1.5f);
    }

    public void EnableSubtitle()
    {
        subtitle.SetActive(true);
    }

    public void PlayAnim()
    {
        anim.SetBool("Expand", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadActivities()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("buttonTest", LoadSceneMode.Single);
    }

    public void BookVisit()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdRksfiIZqBSBL57rZUf_UR9_H0umHbHYnyt3XUjfBE9xrtYA/viewform");
    }

    public void LoadSceneButton()
    {
        //SceneManager.LoadScene("IntoMenu");
    }

}
