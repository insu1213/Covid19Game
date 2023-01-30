using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public float speed = 0.01f;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(new Vector2(0, speed));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-speed, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(new Vector2(0, -speed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(speed, 0));
        }
    }
}
