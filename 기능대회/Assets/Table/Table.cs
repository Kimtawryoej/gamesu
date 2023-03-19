using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjectExample", menuName = "ScriptableObject/ScriptableObjectExample")]
public class Table : ScriptableObject
{
    public int[] score = new int[5]; // ��ŷ���� 4�� �ø��� �ټ���²�� 1������4������ �� ������ á���� ����ǰ� 4������ ������ Ŀ���� 4���� �и��� 4������ ������ �׳� ������� ������
    public string[] Name = new string[5];
}
