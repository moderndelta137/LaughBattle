using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Record : MonoBehaviour
{
    public static MainCamera_Record instance;
    public Camera myCamera;
    public Vector3 initialCenterPos,Player_1_Pos, Player_2_pos;
    public bool isMoving = true;

    void Awake()
    {
        instance = this;
        myCamera = GetComponent<Camera>();
    }

    private void Start()
    {
        Debug.Log("aaa");

        StartCoroutine(_delay(2f));
        

    }

    //void Update()
    //{
        
    //}

    IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        Debug.Log("start moving");
        isMoving = true;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
        Debug.Log("end moving");

    }

    IEnumerator _delay(float delay)
    {
        Debug.Log("oooooo");

        // 指定した秒数待機
        yield return new WaitForSeconds(delay);

        // その後、別のコルーチンを開始
        StartCoroutine(MoveToPosition(Player_1_Pos, 0.5f));
    }
}
