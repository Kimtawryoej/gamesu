using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public enum Type { SetGravity, ReverseGravity }

    public Type type;

    public float Gravity;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (type != Type.SetGravity) return;

        if (other.tag == "player")
        {
            Player.Instance.j = -Gravity;
            Player.Instance.Rigidbody.gravityScale = Gravity;
            Player.Instance.sprite.flipY = Gravity == -1;
        }
    }

    public void OnTriggerStay2D(Collider2D other) // �̷����ϸ� �߷� ������Ʈ ���̿� ���� �־ �� ����� �Ҽ� �ִ�.
    {
        if (type != Type.ReverseGravity) return;

        if (other.tag == "player")
        {
            Player.Instance.j = 1;
            Player.Instance.Rigidbody.gravityScale = -1;
            Player.Instance.sprite.flipY = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (type != Type.ReverseGravity) return;
        if (collision.tag == "player")
        {
            Player.Instance.j = -1;
            Player.Instance.Rigidbody.gravityScale = 1;
            Player.Instance.sprite.flipY = false;
        }
    }
}
