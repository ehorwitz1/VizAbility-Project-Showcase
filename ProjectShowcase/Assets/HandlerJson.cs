using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HandlerJson : MonoBehaviour
{
    public string jsonFilePath = "/Resources/JsonData/Sheet1.txt";
    public JsonCollection jCollection;

    [System.Serializable]
    public class JsonClass
    {
        public string Title;
        public string Tools;
        public string Developer;
        public string Details;
        public string Client;
        public string ImageLocation;
        public string ButtonTitle;

        public JsonClass()
        {
            Title = "";
            Tools = "";
            Developer = "";
            Details = "";
            Client = "";
            ImageLocation = "";
            ButtonTitle = "";
        }

    }

    //This class just holds a list of JsonClass objects, helps read in multiple Json values at a time
    [System.Serializable]
    public class JsonCollection
    {
        public List<JsonClass> objectList = new List<JsonClass>();
    }

    //Given the Json data parse it into individual unity gameobjects
    public void ParseJsonToObject(string json)
    {
        //Set our collection equal to the objects that Unity parsed
        jCollection = JsonUtility.FromJson<JsonCollection>(json);

    }

    // Start is called before the first frame update
    void Start()
    {
        //This will hold all of the 
        jCollection = new JsonCollection();
        //LoadJson();
        LoadAndroidJson();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadJson()
    {
        //Get the filepath
        string filePath = Application.dataPath + jsonFilePath;

        Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            //Read all the Json data into a single string, Unity takes care of the rest
            string dataAsJson = File.ReadAllText(filePath);

            //Just to show what is in the string
            //Debug.Log(dataAsJson);

            dataAsJson = "{\"objectList\" : \n" + dataAsJson + "}";

            //Given all of the Json data parse it into our list of objects
            ParseJsonToObject(dataAsJson);

        }
        else
        {
            Debug.Log("File not found");
        }
    }

    void LoadAndroidJson()
    {
        //Get the filepath
        LoadStreamingJsonAnother();

        Debug.Log(dbPath);

        if (File.Exists(dbPath))
        {
            //Read all the Json data into a single string, Unity takes care of the rest
            string dataAsJson = File.ReadAllText(dbPath);

            //Just to show what is in the string
            //Debug.Log(dataAsJson);

            dataAsJson = "{\"objectList\" : \n" + dataAsJson + "}";

            //Given all of the Json data parse it into our list of objects
            ParseJsonToObject(dataAsJson);

        }
        else
        {
            Debug.Log("File not found");
        }
    }

    string dbPath = "";
    void LoadStreamingJsonAnother()
    {
        // Android
        //string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");
        string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Json.txt");

        // Android only use WWW to read file
        WWW reader = new WWW(oriPath);
        while (!reader.isDone) { }

        //realPath = Application.persistentDataPath + "/db";
        string realPath = Application.persistentDataPath + "/Json";

        System.IO.File.WriteAllBytes(realPath, reader.bytes);

        dbPath = realPath;
    }


}
