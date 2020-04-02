using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public bool expand;
    public ImageLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        expand = false;
    }


    public void Expand()
    {
        Debug.Log("Are we expanding: " + expand);

        if(expand == false)
        {
            expand = true;
            anim.SetBool("Expand", expand);
        }
        else
        {
            expand = false;
            anim.SetBool("Expand", expand);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
