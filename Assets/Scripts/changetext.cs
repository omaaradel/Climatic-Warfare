using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changetext : MonoBehaviour
{
    public TextMeshProUGUI seasontext;
    private string message;
    public int season;
    // Start is called before the first frame update
    //private void Start()
    //{
    //    manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    //}
    void Awake()
    {
        StartCoroutine(Instructions());

        //other code to begin moving a game object
    }

    IEnumerator Instructions()
    {
        //run instructions
        while (true)
        {
            message = "Spring";
            seasontext.text = message;
            season = 0;
            yield return new WaitForSecondsRealtime(10);
            message = "Summer";
            seasontext.text = message;
            season++;
            yield return new WaitForSecondsRealtime(10);
            message = "Autumn";
            season++;
            seasontext.text = message;
            yield return new WaitForSecondsRealtime(10);
            message = "Winter";
            season++;
            seasontext.text = message;
            yield return new WaitForSecondsRealtime(10);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
