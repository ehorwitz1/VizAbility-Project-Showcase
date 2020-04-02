using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    //This holds all the buttons that will be shown
    public List<Button> allButtons;

    //This has all the JsonData in a convenient list
    public HandlerJson JsonHandler;

    //The button prefab that we will be changing
    public GameObject prefabButton;
    //This is what makes them align in a column
    public Transform buttonParent;

    //This is what shows the text on the left side of the screen
    public TextHandler textHandler;

    //Reference to the scroll rect so the buttons can scroll
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
        for (int i = 0; i < JsonHandler.jCollection.objectList.Count; i++)
        {
            //Create a new button
            GameObject newButton = Instantiate(prefabButton) as GameObject;

            //Set the parent of the button so that it aligns in the column
            newButton.transform.SetParent(buttonParent.transform, false);

            //The button has its own class that handles what text it will show when clicked on, matches whats in the JsonClass
            newButton.GetComponent<ButtonClass>().setText(JsonHandler.jCollection.objectList[i].Title.ToUpper(),
                                                          JsonHandler.jCollection.objectList[i].Tools,
                                                          "Developer:\n" + JsonHandler.jCollection.objectList[i].Developer,
                                                          JsonHandler.jCollection.objectList[i].Details,
                                                          JsonHandler.jCollection.objectList[i].Client,
                                                          JsonHandler.jCollection.objectList[i].ImageLocation,
                                                          JsonHandler.jCollection.objectList[i].ButtonTitle);

            //Debug.Log("Adding Button with URL: " + JsonHandler.jCollection.objectList[i].ImageLocation);

            //Add a clickListener that will change whats shown on click
            newButton.GetComponent<Button>().onClick.AddListener(() => ClickedButton(newButton.GetComponent<ButtonClass>()));

            //Add to list of buttons
            allButtons.Add(newButton.GetComponent<Button>());

            //The title of the button is the button title that was in the JsonClass, different than project title
            string buttonTitle = JsonHandler.jCollection.objectList[i].ButtonTitle;

            //This sets the title of the button 
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = buttonTitle;

        }
        //Set the text equal to the info connected to the first button
        textHandler.SetActiveButton(allButtons[0].GetComponent<ButtonClass>());

        scrollRect.verticalScrollbar.value = 1f;

    }

    void ClickedButton(ButtonClass buttonInfo)
    {
        Debug.Log("Button clicked = " + buttonInfo.Title);

        //This will tell the text handler what information to display
        textHandler.SetActiveButton(buttonInfo);
    }
}
