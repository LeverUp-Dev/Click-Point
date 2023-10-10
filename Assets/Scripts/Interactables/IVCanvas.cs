using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour
{
    public Image imgHolder;

    public void Activate(Sprite pic)
    {
        GameManager.ins.currentNode.SetReachableNodes(false);
        GameManager.ins.currentNode.col.enabled = false;
        gameObject.SetActive(true);
        imgHolder.sprite = pic;
    }

    public void Close()
    {
        GameManager.ins.currentNode.SetReachableNodes(true);
        GameManager.ins.currentNode.col.enabled = true;
        gameObject.SetActive(false);
        imgHolder.sprite = null;
    }
}
