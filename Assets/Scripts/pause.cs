using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ispaused = false;
    public GameObject pausemenu;
    public AudioSource confirmbuttonsound;
    private gamemanager manager;
    void Start()
    {
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && manager.active)
        { 
            if (ispaused)
            {
                resume();
            }
            else { pausebutton(); }
        }
     }
   public void pausebutton()
    {
        ispaused = true;
            pausemenu.SetActive(true);
            Time.timeScale = 0;
        
    }
    public void resume()
    {
        ispaused = false;
        confirmbuttonsound.Play();
        pausemenu.SetActive(false);
            Time.timeScale = 1;
        
    }
   


}
