using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : MonoBehaviour
{
    public static Public Instance;
    public float hp = 15;
    public int leavel = 1;
    public int pain = 5;
    public int score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        
        Instance = this;
        DontDestroyOnLoad(gameObject); // ������ �Ѿ�� ��� �� ��ũ��Ʈ�ȿ� �ִ� ������ �������� �ʰ� ��������.
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
