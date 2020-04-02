using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroTypeShower : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
