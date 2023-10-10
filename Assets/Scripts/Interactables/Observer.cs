using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Interactable
{
    public override void Interact()
    {
        GameObject item = Instantiate(gameObject);
        item.transform.SetParent(GameManager.ins.obsCam.rig);
        item.transform.localPosition = Vector3.zero;
        item.transform.GetChild(0).localPosition = Vector3.zero;
        GameManager.ins.obsCam.model = item.transform;
        GameManager.ins.obsCam.gameObject.SetActive(true);
    }
}
