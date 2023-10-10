using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform YAxis;
    public Transform XAxis;
    public float moveTime;

    public void AlignTo(Transform target)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(YAxis.DOMove(target.position, 0.75f));
        seq.Join(YAxis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y, 0f), moveTime));
        seq.Join(XAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));
    }
}
