using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class School : MonoBehaviour
{
    Vector2 one = new Vector2(2, 2); Vector2 two = new Vector2(5, 6);
    float X;
    float Y;
    // Start is called before the first frame update
    void Start()
    {
        float width = Square(3.5f, 2.7f);
        int[] num = new int[2] { 1981, 1891 };
        int Num = MaxNum(num);
        GetDisTance();
        Vector2 distance = new Vector2(X, Y);
        Debug.Log(distance);
    }

    //1¹ø
    float Square(float x, float y)
    {
        return x * y;
    }
    //2¹ø
    int MaxNum(int[] Num)
    {
        return Num.Max();
    }

    void GetDisTance()
    {
        Vector2 result = one - two;

        X = Mathf.Sqrt(Mathf.Pow(result.x, 2));
        Y = Mathf.Sqrt(Mathf.Pow(result.y, 2));
    }
}
