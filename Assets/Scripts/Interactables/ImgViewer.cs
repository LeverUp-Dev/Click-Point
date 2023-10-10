using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgViewer : Interactable
{
    public Sprite pic;

    public override void Interact()
    {
        GameManager.ins.IVCanvas.Activate(pic);
    }
}
