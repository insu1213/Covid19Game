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
        player = GameObject.Find("Player").transform; //플레이어 오브젝트 찾기
        playerFound = player.position; // 플레이어의 포지션을 2.5초 마다 저장 (바이러스가 과도하게 플레이어를 쫒아오지 못하도록)
        // 정확히 무엇이 좋은지 잘 모르겠다.
        // 1) 2.5초마다 플레이어의 위치를 저장하여 해당 위치를 기반으로 이동하는 것
        // 2) 랜덤 초마다 플레이어의 위치를 저장하여 해당 위치를 기반으로 이동하는 것
        // 3) 2.5초마다 플레이어의 위치를 저장하되, 어느 특정 거리까지 가까워질 때까지는 넓은 범위에서의 랜덤 값 이동, 특정 거리 이내로 가까워졌을 때 해당 위치를 기반으로 이동
        canvas = GetComponentInParent<Canvas>();
    }

  
    void Update()
    {
        // 2.5초마다 플레이어의 위치를 저장하는 로직
        if (check)
        {
            check = false;
            playerFound = player.position;
            StartCoroutine(WaitForIt());
        }

        // Distance 보다 가까워질 때까지 이동
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
        Debug.Log("플레이어 위치 저장됨");
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
