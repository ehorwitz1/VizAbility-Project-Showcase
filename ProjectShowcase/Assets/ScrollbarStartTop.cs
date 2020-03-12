using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarStartTop : MonoBehaviour
{
    Scrollbar bar;

    public IEnumerator Start()
    {
        Debug.Log("Now its called");
        yield return null; // Waiting just one frame is probably good enough, yield return null does that
        bar = GetComponentInChildren<Scrollbar>();
        bar.value = 1;
        Debug.Log("Now its setted");
    }
}
