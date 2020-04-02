using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClass: MonoBehaviour
{
    //The button holds info thats very similar to the Json Class, the textHandler gets this info when a button is clicked on
    public string Title;
    public string Tools;
    public string Developer;
    public string Details;
    public string Client;
    public string ImageLocation;
    public string ButtonTitle;


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
