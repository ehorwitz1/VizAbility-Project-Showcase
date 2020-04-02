using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ImageLoader : MonoBehaviour
{
    public string url = "http://www.uwyo.edu/ser/_files/images/mastheads/eic-south-view01.jpg";
    //public Renderer thisRenderer;

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());
    }



    public IEnumerator GetText()
    {
        if (string.Compare(url, "") != 0)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    // Get downloaded asset bundle
                    var texture = DownloadHandlerTexture.GetContent(uwr);
                    img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                }
            }
        }
    }


    public void SetURL(string URL)
    {
        //url = URL.Replace("'\\'", string.Empty);
        url = URL;
        Debug.Log("Setting URL" + url);
        if(img.IsActive() == false)
        {
            Debug.Log("SETTING UP THE IMAGE");
            img.gameObject.SetActive(true);
            StartCoroutine(GetText());
        }
        StartCoroutine(GetText());
    }
}
