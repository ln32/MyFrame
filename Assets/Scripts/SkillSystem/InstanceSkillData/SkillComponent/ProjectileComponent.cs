using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public SpriteRenderer projectileImage;
    public float reachTime;

    public Vector3 srcV3;
    public Vector3 dstV3;
    public float lifeTime;

    public float ReachTime => reachTime;

    private void Update()
    {
        lifeTime += Time.deltaTime;

        // 이동 거리 내에 대상이 있는가 ? 적중 : 이동
        if (reachTime < lifeTime)
            OnHit();
        else
            transform.position = Vector3.Lerp(srcV3, dstV3, lifeTime / reachTime);
    }

    private void OnHit()
    {
        NabeDebug.Log("OnHit");

        Destroy(gameObject);
    }
}