using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextHandler : MonoBehaviour
{
    //Holds all of the text elements that will be changed
    public List<TextMeshProUGUI> guiList;

    //Reference to active button
    ButtonClass activeButton;

    //This loads an image from the web
    public ImageLoader loadImage;

    public TextMeshProUGUI scrollText;
    public ScrollRect scrollRect;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            guiList.Add(child.GetComponent<TextMeshProUGUI>());
        }
        //Kept having a hard time setting the scrollbar value
        scrollRect.verticalScrollbar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This gets called when the buttons are clicked on. It sets the text equal to whats in the button
    public void SetActiveButton(ButtonClass buttonInfo)
    {
        //Get the buttonInfo from the active button
        activeButton = buttonInfo;

        //Go through all the text elements 
        setAllText();
    }

    public void setAllText()
    {
        //Set the title
        guiList[0].SetText(activeButton.Title);

        //Set the details
        guiList[1].SetText(activeButton.Details);
        scrollText.SetText(activeButton.Details);
        scrollRect.verticalScrollbar.value = 1f;


        //Set the tools
        guiList[2].SetText("Tools:\n" + activeButton.Tools);


        //Developer
        guiList[3].SetText(activeButton.Developer);
        

        //Set the collaborator
        guiList[4].SetText("Client:\n" + activeButton.Client);

        //Check to see if we need to show an image or not
        if(activeButton.ImageLocation.CompareTo("") == 0)
        {
            Debug.Log("No URL GIVEN");
            anim.SetBool("HasImage", false);
            
        }
        else
        {
            anim.SetBool("HasImage", true);
            Debug.Log("Setting URL: " + activeButton.ImageLocation);
            loadImage.SetURL(activeButton.ImageLocation);
            scrollRect.verticalScrollbar.value = 1f;
        }

        

    }



    //This is pretty much equivalent to the JsonClass. This class and the JsonClass could be combined to make things easier
    [System.Serializable]
    public class textHolder
    {
        public string Category;
        public string Title;
        public string Tools;
        public string Developer;
        public string Collaborator;
        public string Details;

        public textHolder()
        {
            Category = "";
            Title = "";
            Tools = "";
            Developer = "";
            Collaborator = "";
            Details = "";
        }

        public void setText(string cat, string title, string tools, string developer, string collab, string details)
        {
            this.Category = cat;
            this.Title = title;
            this.Tools = tools;
            this.Developer = developer;
            this.Collaborator = collab;
            this.Details = details;
        }

    }
}
