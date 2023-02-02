using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char : MonoBehaviour
{
    public float speed = 0.5f;
    public float maxVelocityX = 10f;
    public float maxVelocityY = 10f;
    private Rigidbody2D rigid;
    Animator anim;
    bool spaceCK = true;
    public float hp;
    public Virus virus;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hp = 1f;
        virus = null;
    }

    // Update is called once per frame


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                
                
                if(touchedObject.tag == "Virus")
                {
                    Debug.Log(touchedObject.tag);
                    virus = touchedObject.GetComponent<Virus>();
                    virus.hp -= 0.5f;
                }
            }
        }

                if (Input.GetKey(KeyCode.W))
        {
            if(rigid.velocity.y < maxVelocityY)
            {
                rigid.AddForce(new Vector2(0, 300) * Time.deltaTime);
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(rigid.velocity.x > maxVelocityX * -1)
            {
                rigid.AddForce(new Vector2(-300, 0) * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if(rigid.velocity.y > maxVelocityY * -1)
            {
                rigid.AddForce(new Vector2(0, -300) * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if(rigid.velocity.x < maxVelocityX)
            {
                rigid.AddForce(new Vector2(300, 0) * Time.deltaTime);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && spaceCK)
        {
            anim.SetBool("Attack", true);
            spaceCK = false;
        } 
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Attack", false);
            spaceCK = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Virus")
        {
            Debug.Log("병원균과 접촉하였습니다.");
            hp -= 0.1f;
            
        }
    }
}
