using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public List<Button> allButtons;
    public HandlerJson JsonHandler;

    public GameObject prefabButton;
    public Transform buttonParent;

    public TextHandler textHandler;
    public ScrollRect scrollRect;

    // Start is called before the first frame update
    void Start()
    {
        allButtons = new List<Button>();
        buttonParent = this.transform;

        JsonHandler = GameObject.Find("JsonHandler").GetComponent<HandlerJson>();

        Invoke("SetButtons", .001f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtons()
    {
        

        //allButtons[0].GetComponentInChildren<Text>().text = JsonHandler.jCollection.objectList[0].Title;
        for (int i = 0; i < JsonHandler.jCollection.objectList.Count; i++)
        {
            GameObject newButton = Instantiate(prefabButton) as GameObject;
            newButton.transform.SetParent(buttonParent.transform, false);

            Debug.Log("Developer: " + JsonHandler.jCollection.objectList[i].Tools);

            newButton.GetComponent<ButtonClass>().setText(JsonHandler.jCollection.objectList[i].Title.ToUpper(),
                                                          JsonHandler.jCollection.objectList[i].Tools,
                                                          "Developer:\n" + JsonHandler.jCollection.objectList[i].Developer,
                                                          JsonHandler.jCollection.objectList[i].Details,
                                                          JsonHandler.jCollection.objectList[i].Client,
                                                          JsonHandler.jCollection.objectList[i].ImageLocation,
                                                          JsonHandler.jCollection.objectList[i].ButtonTitle);

            Debug.Log("Adding Button with URL: " + JsonHandler.jCollection.objectList[i].ImageLocation);

            newButton.GetComponent<Button>().onClick.AddListener(() => ClickedButton(newButton.GetComponent<ButtonClass>()));

            allButtons.Add(newButton.GetComponent<Button>());

            string buttonTitle = JsonHandler.jCollection.objectList[i].ButtonTitle;


            //allButtons[i].GetComponentInChildren<Text>().text = buttonTitle;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = buttonTitle;

        }

        textHandler.SetActiveButton(allButtons[0].GetComponent<ButtonClass>());

        scrollRect.verticalScrollbar.value = 1f;

    }

    void ClickedButton(ButtonClass buttonInfo)
    {
        Debug.Log("Button clicked = " + buttonInfo.Title);
        textHandler.SetActiveButton(buttonInfo);
    }
}
