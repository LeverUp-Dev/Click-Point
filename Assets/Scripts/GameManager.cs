using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public IVCanvas IVCanvas;
    public ObsCamera obsCam;

    public MNode startingNode;

    [HideInInspector]
    public MNode currentNode;

    public CameraRig rig;

    void Awake()
    {
        ins = this;
        IVCanvas.gameObject.SetActive(false);
        obsCam.gameObject.SetActive(false);
    }

    void Start()
    {
        startingNode.Arrive();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null) {
            if (IVCanvas.gameObject.activeInHierarchy) {
                IVCanvas.Close();
                return;
            }
            if (obsCam.gameObject.activeInHierarchy) {
                obsCam.Close();
                return;
            }
            currentNode.GetComponent<Prop>().location.Arrive();
        }
    }
}
