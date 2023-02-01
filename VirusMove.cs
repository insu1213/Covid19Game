using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMove : MonoBehaviour
{
    public float speed = 1;
    public float distance = 0.1f;
    public float killDistance = 10;
    Transform player;
    public bool check = true;
    int directionX = 0;
    int directionY = 0;
    Vector2 playerFound;
    Canvas canvas;


    void Start()
    {
        player = GameObject.Find("Player").transform; //�÷��̾� ������Ʈ ã��
        playerFound = player.position; // �÷��̾��� �������� 2.5�� ���� ���� (���̷����� �����ϰ� �÷��̾ �i�ƿ��� ���ϵ���)
        // ��Ȯ�� ������ ������ �� �𸣰ڴ�.
        // 1) 2.5�ʸ��� �÷��̾��� ��ġ�� �����Ͽ� �ش� ��ġ�� ������� �̵��ϴ� ��
        // 2) ���� �ʸ��� �÷��̾��� ��ġ�� �����Ͽ� �ش� ��ġ�� ������� �̵��ϴ� ��
        // 3) 2.5�ʸ��� �÷��̾��� ��ġ�� �����ϵ�, ��� Ư�� �Ÿ����� ������� �������� ���� ���������� ���� �� �̵�, Ư�� �Ÿ� �̳��� ��������� �� �ش� ��ġ�� ������� �̵�
        canvas = GetComponentInParent<Canvas>();
    }

  
    void Update()
    {
        // 2.5�ʸ��� �÷��̾��� ��ġ�� �����ϴ� ����
        if (check)
        {
            check = false;
            playerFound = player.position;
            StartCoroutine(WaitForIt());
        }

        // Distance ���� ������� ������ �̵�
        if (Vector2.Distance(playerFound, transform.position) > distance)
        {
            transform.Translate(new Vector2(directionX, directionY) * Time.deltaTime);
            Direction(playerFound);
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
        check = true;
        Debug.Log("�÷��̾� ��ġ �����");
    }

    void Direction(Vector2 pos)
    {
        if (transform.position.x - playerFound.x < 0)
            directionX = 1;
        //transform.eulerAngles = new Vector3(0, 180, 0);
        else
            directionX = -1;

        if(transform.position.y - playerFound.y < 0)
            directionY = 1;
        else 
            directionY = -1;
    }

    

}
