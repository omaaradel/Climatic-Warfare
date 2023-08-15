using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalinput;
    private float verticalinput;
    private Rigidbody playerrb;
    public float speed = 10f;
    public float rotationspeed = 10f;
    private float timetofreeze = 0;
    private bool iswaiting=false;
    Vector3 startingpoint;
    private Animator animator;
    private CharacterController characterController;
    private gamemanager manager;
    public GameObject respawnps;
    public AudioSource respawnsound;


    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }

  
   private void Update()
    {

        if (iswaiting || !manager.active)
        {
            speed = 0;
        }
        else {
            speed = 40;
          }
            horizontalinput = Input.GetAxis("Horizontal") * speed;
            verticalinput = Input.GetAxis("Vertical") * speed;
        
            startingpoint = new Vector3(horizontalinput, 0, verticalinput);
            float magnet = Mathf.Clamp01(startingpoint.magnitude) * speed;
            startingpoint.Normalize();

        
        
            transform.Translate(startingpoint * magnet * Time.deltaTime, Space.World);
            characterController.SimpleMove(startingpoint * magnet);
        
        
        
        
         
        if (transform.position.x > 82f)
        {
            transform.position = new Vector3(82f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -82f)
        {
            transform.position = new Vector3(-82f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 77.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 77.5f);
        }
        else if (transform.position.z < -77.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -77.5f);
        }

        if (startingpoint!=Vector3.zero)
        {
            animator.SetBool("ismoving", true);
            Quaternion torotation = Quaternion.LookRotation(startingpoint, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, torotation, rotationspeed*Time.deltaTime);
        }
        else
        {
            animator.SetBool("ismoving", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fallenemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            manager.sublives();
            manager.DestroyAllEnemies();
            respawn();
        }
        if (collision.gameObject.CompareTag("winterenemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            manager.sublives();
            manager.DestroyAllEnemies();
            respawn();
        }
        if (collision.gameObject.CompareTag("summerenemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            manager.sublives();
            manager.DestroyAllEnemies();
            respawn();
        }
        if (collision.gameObject.CompareTag("springenemy") && !collision.gameObject.CompareTag("Bullet"))
        {
            manager.sublives();
            manager.DestroyAllEnemies();
            respawn();
        }
    }
    private void respawn()
    { 
        characterController.enabled = false;
        respawnsound.Play();
        transform.position = new Vector3(0, 1, 0);
        transform.rotation = Quaternion.identity;
        
        Instantiate(respawnps, transform.position, respawnps.transform.rotation);
        StartCoroutine(Wait());
        characterController.enabled = true ;
    }
    IEnumerator Wait()
    {
        iswaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(1.4f); // wait for sec
        iswaiting = false; // set the bool to start moving

    }

}
