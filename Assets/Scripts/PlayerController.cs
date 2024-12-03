using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameManager myGameManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.Translate(0,0,1);
        transform.Translate(Vector3.forward*Time.deltaTime*20);
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -5);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up,5);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("itemGood"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if(collision.CompareTag("itemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if(collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
        
       
    }

    void  PlayerDeath()
    {
        SceneManager.LoadScene("Driving3D");
    }
}
