using UnityEngine;

public class SingleTargetProjectile : CastVisualComponent
{
    private void Update()
    {
        lifeTime += Time.deltaTime;

        if (reachTime < lifeTime)
        {
            onHit?.Invoke(dstV3);
        }

        if (reachTime < lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.Lerp(srcV3, dstV3, lifeTime / reachTime);
        }
    }
}