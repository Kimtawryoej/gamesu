using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Node
{
    public int x, y, G, H;
    public bool wall;
    public Node ParentNode;
    public Node(int _x, int _y, bool _wall)
    {
        x = _x;
        y = _y;
        wall = _wall;
    }
    public int F { get { return G + H; } }

}
public class GameManager : MonoBehaviour
{
    public Vector2Int size, startPos, targetPos;
    public List<Node> FinalNodeList;
    public bool allowDiagonal, dontCrossCorner;
    Node[,] NodeArray;
    public int[] F;
    public int[] H;
    Node startNode, targetNode, curNode;
    List<Node> OpenList, CloseList;
    public void PathPinding()
    {
        NodeArray = new Node[size.x, size.y];
        for (int i = 0; i < size.x; i++) //맵 세팅
        {
            for (int j = 0; j < size.y; j++)
            {
                bool wall = false;
                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i, j), 0.4f))
                {
                    if (col.CompareTag("wall"))
                    {
                        wall = true;
                    }
                }
                NodeArray[i, j] = new Node(i, j, wall);
            }
        }
        startNode = NodeArray[startPos.x, startPos.y];
        targetNode = NodeArray[targetPos.x, targetPos.y];
        OpenList = new List<Node>() { startNode };
        CloseList = new List<Node>();
        FinalNodeList = new List<Node>();
        while (OpenList.Count > 0)
        {
            curNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)//OpenList에서(현재 노트까지의 최단비용 + 목표까지의 예상비용)이 가장적을것을 고르는 과정
                if (OpenList[i].F <= curNode.F && OpenList[i].H < curNode.H) curNode = OpenList[i];
            OpenList.Remove(curNode);
            CloseList.Add(curNode);
            if (curNode == targetNode)//구해진 최단거리를 타겟부터 거슬러 올라오면서 FinalNodeList에 넣어주는 과정
            {
                Node TargetCurNode = targetNode;
                while (TargetCurNode != startNode)
                {
                    FinalNodeList.Add(TargetCurNode);
                    TargetCurNode = TargetCurNode.ParentNode;
                }
                FinalNodeList.Add(startNode);
                FinalNodeList.Reverse();

                for (int i = 0; i < FinalNodeList.Count; i++) print(i + "번째는 " + FinalNodeList[i].x + ", " + FinalNodeList[i].y);
                return;
            }

            if (allowDiagonal)
            {
                OpenListAdd(curNode.x + 1, curNode.y + 1);
                OpenListAdd(curNode.x - 1, curNode.y + 1);
                OpenListAdd(curNode.x - 1, curNode.y - 1);
                OpenListAdd(curNode.x + 1, curNode.y - 1);
            }

            OpenListAdd(curNode.x, curNode.y + 1);
            OpenListAdd(curNode.x + 1, curNode.y);
            OpenListAdd(curNode.x, curNode.y - 1);
            OpenListAdd(curNode.x - 1, curNode.y);
        }
    }


    void OpenListAdd(int checkX, int checkY)
    {
        if (checkY < 0 || checkX < 0 || checkX >= size.x || checkY >= size.y || NodeArray[checkX, checkY].wall || CloseList.Contains(NodeArray[checkX, checkY]))
        {
            return; //있는 포인트인지 없는 포인트인지 확인
        }
        Node NeighborNode = NodeArray[checkX, checkY];
        int MoveCost = curNode.G + (curNode.x - checkX == 0 || curNode.y - checkY == 0 ? 10 : 14);
        //현재 노트까지의 최단 비율


        if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
        {
            NeighborNode.G = MoveCost;
            NeighborNode.H = (Mathf.Abs(NeighborNode.x - targetNode.x) + Mathf.Abs(NeighborNode.y - targetNode.y)) * 10;
            //목표노드까지의 예상 비율
            NeighborNode.ParentNode = curNode;

            OpenList.Add(NeighborNode);
        }
    }

    void OnDrawGizmos()
    {
        if (FinalNodeList.Count != 0) for (int i = 0; i < FinalNodeList.Count - 1; i++)
            {
                Gizmos.DrawLine(new Vector2(FinalNodeList[i].x, FinalNodeList[i].y), new Vector2(FinalNodeList[i + 1].x, FinalNodeList[i + 1].y));
            }
    }
}
