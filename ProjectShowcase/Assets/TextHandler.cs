using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextHandler : MonoBehaviour
{
    public List<TextMeshProUGUI> guiList;

    ButtonClass activeButton;

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
        scrollRect.verticalScrollbar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveButton(ButtonClass buttonInfo)
    {
        activeButton = buttonInfo;
        setAllText();
        //loadImage.gameObject.SetActive(false);
    }

    public void setAllText()
    {
        //Set the title
        guiList[0].SetText(activeButton.Title);

        //Set the details
        guiList[1].SetText(activeButton.Details);
        scrollText.SetText(activeButton.Details);
        Debug.Log(scrollText.text.Split('\n').Length);
        scrollRect.verticalScrollbar.value = 1f;


        //Set the tools
        guiList[2].SetText("Tools:\n" + activeButton.Tools);


        //Developer
        guiList[3].SetText(activeButton.Developer);
        

        //Set the collaborator
        guiList[4].SetText("Client:\n" + activeButton.Client);


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
