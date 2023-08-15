using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyrb;
    public float espeed = 10;
    private float maxespeed=40;
    private float acceleration = 0.15f;
    private Transform playerTarget;
    private Vector3 movement;   
    public GameObject explotion;
    private gamemanager manager;
    void Start()
    {
         enemyrb = GetComponent<Rigidbody>();
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected virtual void Update()
    {
        Vector3 direction = playerTarget.position - transform.position;
        direction.Normalize();
        movement = direction;
        

    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector3 direction)
    {
        espeed += (acceleration *Time.deltaTime);
        if (espeed > maxespeed)
        {
            espeed = maxespeed;
        }
            enemyrb.MovePosition((Vector3)transform.position + (direction * espeed * Time.deltaTime));
    }
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "Bullet" )
    //    {
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject);
    //    }
    //}
    public virtual void DestroyEnemy(bool destroyByPlayer = false)
    {
        //Explotion particle system play
        GameObject cloneExplotion = Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(cloneExplotion, 0.8f);
        Destroy(gameObject);
    }


}
