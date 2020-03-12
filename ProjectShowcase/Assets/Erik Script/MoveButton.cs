using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    RectTransform canvas;
    RectTransform button;
    Vector3 startingPosition;
    public float speed;
    Vector3 middleVect;

    void Start()
    {
        button = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        speed = -10f;
         middleVect = new Vector3(canvas.rect.width / 2, (canvas.rect.height) - canvas.rect.height / 8, 5);
    }

    void Update()
    {
        //transform.Translate(0f, speed, 0f);
        //if (button.position.y < -button.rect.height)
            //transform.position = new Vector3(startingPosition.x, canvas.rect.height + button.rect.height, startingPosition.z);
        
        transform.position = Vector3.Lerp(button.transform.position, middleVect, Time.deltaTime * 2);

        if(Input.GetMouseButton(0))
        {
            middleVect = Input.mousePosition;
            Debug.Log(middleVect);
        }

    }
    
}
