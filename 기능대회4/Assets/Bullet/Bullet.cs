using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SingleTone<Bullet>
{
    [SerializeField]
    float Speed;
    public float SpeedGet { get => Speed; set => Speed = value; }
    public int PatternChange = 0;
    public int SaveCount;
    public Dictionary<int, Vector3> SaveAngle = new Dictionary<int, Vector3>();
    Dictionary<int, int> PatternChangeSave = new Dictionary<int, int>();
    public int PatternChangeSaveGet
    {
        get => SaveCount;
        set
        {
            foreach (var a in PatternChangeSave)
            {
                if (value == a.Key)
                {
                    SaveCount = a.Value;
                }
            }
        }
    }
    public Dictionary<int, Vector3> PatternAngle = new Dictionary<int, Vector3>();
    public Dictionary<int, Vector3> PatternAngleGet
    {
        get => SaveAngle;
        set
        {
            foreach (var a in PatternAngle)
            {
                if (value.ContainsKey(a.Key))
                {
                    SaveAngle.Clear();
                    SaveAngle.Add(a.Key, a.Value);

                }
            }
        }
    }
    public void Ins()
    {
        PatternChangeSave = new Dictionary<int, int>
        {
            {0,1},
            {1,15},
        };
        PatternAngle = new Dictionary<int, Vector3>
        {
            {1,new Vector3(0,0,0)},
            {15,new Vector3(0,24,0)},
        };

        PatternChangeSaveGet = PatternChange;
        //Debug.Log(SaveCount);
        SaveAngle.Add(SaveCount, new Vector3(0, 0, 0));
        PatternAngleGet = SaveAngle;


    }


    public void Lookattransform(Transform trans)
    {
        trans.position +=  trans.forward* Speed * Time.deltaTime;
    }
    public void trans(Transform trans)
    {
        trans.Translate(Speed * Time.deltaTime, 0, 0);
    }

    public void Bulletshot(float Count, Vector3 Angle, Transform MYposition, GameObject Mon)
    {
        for (int i = 0; i < Count; i++)
        {
            Instantiate(Mon, MYposition.position, Quaternion.Euler(Angle*i));
        }
    }

    public IEnumerator Des(GameObject gam)
    {
        yield return new WaitForSeconds(3);
        Destroy(gam);
    }
}
