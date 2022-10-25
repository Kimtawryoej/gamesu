using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    float curDelay;
    public GameObject capsul;
    public GameObject RangeObject;
    BoxCollider2D rangeCollider;

    [SerializeField] GameObject MonsterPrefab;
    //------------------------------------------------------------------
    private void Awake()
    {
        rangeCollider = GetComponent<BoxCollider2D>();
    }
    //-----------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        if (curDelay > 5f)
        {
            StartCoroutine(RandomRespawn_co());
            curDelay = 0;
            Debug.Log(curDelay);
            Monster mon = PoolingManager.Instance.Getmonster();
        }
        curDelay += Time.deltaTime;

    }
    //-------------------------------------------------------------------------------------
    Vector3 Return_RandomPosition()
    {
        Vector2 originPosition = RangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector2 RandomPostion = new Vector2(range_X, range_Y);

        Vector2 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    IEnumerator RandomRespawn_co()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
        }
    }

    //---------------------------------------------------------------------------------------------------------------















}
