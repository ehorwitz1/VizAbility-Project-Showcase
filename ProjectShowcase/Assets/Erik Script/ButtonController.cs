using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script did not end up being used
public class ButtonController : MonoBehaviour
{
    public List<RectTransform> childRect;
    RectTransform canvas;


    // Start is called before the first frame update
    void Start()
    {
        foreach(RectTransform transforms in transform)
        {
            if (transforms.gameObject.name.Contains("Button"))
            {
                childRect.Add(transforms);
            }
        }

        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        StartPositions();
    }

    void StartPositions()
    {
        int posIndex = 1;
        foreach(RectTransform rect in childRect)
        {
            //Verticle buttons
            //Vector3 buttonPos =  new Vector3(canvas.rect.width / 2, (canvas.rect.height/5) * posIndex, 5);

            //Horizontal buttons
            Vector3 buttonPos = new Vector3( (canvas.rect.width / 5) * posIndex, canvas.rect.height / 2, 5);

            rect.transform.position = Vector3.Lerp(rect.transform.position, buttonPos, Time.deltaTime * 2);
            posIndex++;
        }
    }
}
