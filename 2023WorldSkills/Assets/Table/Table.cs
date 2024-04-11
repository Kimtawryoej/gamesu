using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjectExample", menuName = "ScriptableObject/ScriptableObjectExample")]
public class Table : ScriptableObject
{
    public int[] score = new int[5]; // 랭킹에는 4명만 올리고 다섯번짼는 1번부터4번까지 다 점수가 찼을떄 실행되고 4번보다 점수가 커지면 4번이 밀리고 4번보다 작으면 그냥 사라지는 데이터
    public string[] Name = new string[5];
}
