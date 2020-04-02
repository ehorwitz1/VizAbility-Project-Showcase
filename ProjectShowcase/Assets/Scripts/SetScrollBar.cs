using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScrollBar : MonoBehaviour
{
    public ScrollRect rect;

    // Start is called before the first frame update
    void Start()
    {
        //rect.verticalScrollbar.value = .99f;
        Invoke("setValue", .1f);
    }

    // Update is called once per frame
    void Update()
    {
        //rect.verticalScrollbar.value = .99f;
    }

    void setValue()
    {
        rect.verticalScrollbar.value = .9999f;
    }

}
