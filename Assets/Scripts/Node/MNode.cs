using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class MNode : MonoBehaviour
{
    public Transform camPos;
    public List<MNode> reachableNodes = new List<MNode>();

    [HideInInspector]
    public Collider col;

    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void OnMouseDown()
    {
        Arrive();
    }

    public virtual void Arrive()
    {
        //방문한 노드를 그대로 두기
        if(GameManager.ins.currentNode != null)
            GameManager.ins.currentNode.Leave();
        //현재 node 설정
        GameManager.ins.currentNode = this;
        //카메라 움직이기
        GameManager.ins.rig.AlignTo(camPos);
        //자신의 콜라이더 끄기
        if(col != null)
            col.enabled = false;
        //방문한 모든 노드의 콜라이더 켜기
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //방문한 모든 노드의 콜라이더 끄기
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        foreach (MNode node in reachableNodes) {
            if (node.col != null) {
                node.col.enabled = set;
            }
        }
    }
}
