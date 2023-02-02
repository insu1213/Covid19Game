using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Virus : MonoBehaviour
{
    public float speed = 1;
    public float distance = 0.1f;
    public float killDistance = 4;
    public float sensRadius = 4;
    Transform player;
    public bool check = true;
    int directionX = 0;
    int directionY = 0;
    Vector2 playerFound;
    public float hp;
    [SerializeField] GameObject m_goPrefab = null;
    List<Transform> m_objectList = new List<Transform>();
    List<GameObject> m_hpBarList = new List<GameObject>();

    Camera m_cam = null;

    void Start()
    {
        player = GameObject.Find("Player").transform; //�÷��̾� ������Ʈ ã��
        playerFound = player.position; // �÷��̾��� �������� 2.5�� ���� ���� (���̷����� �����ϰ� �÷��̾ �i�ƿ��� ���ϵ���)
        // ��Ȯ�� ������ ������ �� �𸣰ڴ�.
        // 1) 2.5�ʸ��� �÷��̾��� ��ġ�� �����Ͽ� �ش� ��ġ�� ������� �̵��ϴ� ��
        // 2) ���� �ʸ��� �÷��̾��� ��ġ�� �����Ͽ� �ش� ��ġ�� ������� �̵��ϴ� ��
        // 3) 2.5�ʸ��� �÷��̾��� ��ġ�� �����ϵ�, ��� Ư�� �Ÿ����� ������� �������� ���� ���������� ���� �� �̵�, Ư�� �Ÿ� �̳��� ��������� �� �ش� ��ġ�� ������� �̵�
        
        hp = 1;

        m_cam = Camera.main;
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);

        }
    }

  
    void Update()
    {
        
        float random = Random.Range(-3.00f, 3.00f);

        for(int i = 0; i < m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.15f, 0));
        }

        // 2.5�ʸ��� �÷��̾��� ��ġ�� �����ϴ� ����
        if (check)
        {
            check = false;
            playerFound = new Vector2(player.position.x + random, player.position.y + random);
            StartCoroutine(WaitForIt());
        }

        // Distance ���� ������� ������ �̵� (�����Ÿ� ������)
        if (Vector2.Distance(playerFound, transform.position) > distance && 
            Vector2.Distance(playerFound, transform.position) < sensRadius)
        {
            transform.Translate(new Vector2(directionX, directionY) * Time.deltaTime * speed);
            Direction(playerFound);
        }

        
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.5f);
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
