using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MNode
{
    public Location location;
    Interactable inter;

    void Start()
    {
        inter = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if(inter != null && inter.enabled) {
            inter.Interact();
            return;
        }

        base.Arrive();

        //오브젝트 상호작용 만들기
        if(inter != null) {
            col.enabled = true;
            inter.enabled = true;
        }
    }

    public override void Leave()
    {
        base.Leave();

        if(inter != null) {
            inter.enabled= false;
        }
    }
}
