using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject splayer;
    public Vector3 vector;
    public float Speed;
    public float JumpSpeed;
    private bool IsCatching=false;
    public static int EnemyHealth=5;
    private bool IsGround=true;
    Rigidbody enemybody;
    private player player;
    void Start()
    {
        enemybody = this.GetComponent<Rigidbody>();
        Invoke("Changestate", 3f);
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(IsGround)
            {
                IsCatching = false;
                Invoke("Changestate", 3f);

            }
            else
            {
                EnemyHealth -= 1;
                //Invoke("Changestate", 3f);
            }
            
        }
        if(collision.gameObject.tag == "Ground")
        {
            
            IsGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            IsGround = false;
        }
      
    }
    
    private void LateUpdate()
    {
        if (IsCatching && splayer)
        {
            //Debug.Log(player.isGround);
            if(player.isGround)
            {
                 vector = splayer.transform.position - transform.position;
                 enemybody.AddForce(vector * Speed);
                
            }
            if (!player.isGround)
            {
                float vectory = splayer.transform.position.y - transform.position.y;
                enemybody.AddForce(new Vector3(0,vectory,0) * JumpSpeed);
            }

        }
   
    }
    void Changestate()
    {
        IsCatching = true;
    }

}
