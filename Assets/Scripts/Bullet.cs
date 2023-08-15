using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private gamemanager manager;
    private changetext seasonnumber;
    public AudioSource killedsound;
    
    // Start is called before the first frame update
    private void Start()
    {
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        seasonnumber= GameObject.Find("Canvas").GetComponent<changetext>();
    }
   
    private void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.CompareTag("springenemy") && seasonnumber.season==0)
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.addscore(20);
            Debug.Log("you have killed  spring");
        }
        if (collision.gameObject.CompareTag("summerenemy") && seasonnumber.season == 1)
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.addscore(20);
            Debug.Log("you have killed summer");
        }

        if (collision.gameObject.CompareTag("fallenemy") && seasonnumber.season == 2)
        {
           
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.addscore(20);
            Debug.Log("you have killed fall");
        }
        if (collision.gameObject.CompareTag("winterenemy") && seasonnumber.season == 3)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            manager.addscore(20);
            Debug.Log("you have killed winter");
        }

    }
   
    private void Update()
    {
     
        if (transform.position.x > 82f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -82f)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > 77.5f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -77.5f)
        {
            Destroy(gameObject);
        }
    }

}
