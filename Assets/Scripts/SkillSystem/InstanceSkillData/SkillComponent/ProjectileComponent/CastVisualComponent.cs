using System;
using UnityEngine;

public class CastVisualComponent : MonoBehaviour
{
    public SpriteRenderer projectileImage;

    public Vector3 srcV3;
    public Vector3 dstV3;

    public float lifeTime;
    public float projectileSpeed;

    public float reachTime;

    internal Action<Vector3> onHit = v3 =>
    {
        // 이펙트용 맞은자리 v3 존재
        //NabeDebug.Log("OnHit : " + v3);
    };

    public void SetReachTime()
    {
        reachTime = Vector3.Distance(srcV3, dstV3) / projectileSpeed;

        Vector2 newPos = dstV3 - srcV3;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void AddAction(Action<Vector3> hitAction)
    {
        onHit += hitAction;
    }
}