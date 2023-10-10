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
        //�湮�� ��带 �״�� �α�
        if(GameManager.ins.currentNode != null)
            GameManager.ins.currentNode.Leave();
        //���� node ����
        GameManager.ins.currentNode = this;
        //ī�޶� �����̱�
        GameManager.ins.rig.AlignTo(camPos);
        //�ڽ��� �ݶ��̴� ����
        if(col != null)
            col.enabled = false;
        //�湮�� ��� ����� �ݶ��̴� �ѱ�
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //�湮�� ��� ����� �ݶ��̴� ����
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
