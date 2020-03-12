using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClass: MonoBehaviour
{
    public string Title;
    public string Tools;
    public string Developer;
    public string Details;
    public string Client;
    public string ImageLocation;
    public string ButtonTitle;
    /*
    public ButtonClass()
    {
        Category = "";
        Title = "";
        Tools = "";
        Developer = "";
        Collaborator = "";
        Details = "";
    }*/

    public void setText(string title, string tools, string developer, string details, string client, string imageLoc, string bTitle)
    {
        this.Title = title;
        this.Tools = tools;
        this.Developer = developer;
        this.Details = details;
        this.Client = client;
        this.ImageLocation = imageLoc;
        this.ButtonTitle = bTitle;
    }
}
