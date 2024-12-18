using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public SpriteRenderer projectileImage;

    public float projectileSpeed;
    public Vector3 target;
    public float ReachTime => Vector2.Distance(transform.position, target) / projectileSpeed;

    private void Update()
    {
        Vector3 previousPosition = transform.position;

        // 타겟 방향 계산 (Z축 일치시킴)
        var target2D = GetAngle(out var directionToTarget, out var projectedDistance);

        // 이동 거리 내에 대상이 있는가 ? 적중 : 이동
        if (projectedDistance >= Vector3.Distance(previousPosition, target2D))
        {
            OnHit();
        }
        else
        {
            MoveProjectile(directionToTarget, projectedDistance);
        }
    }

    private void MoveProjectile(Vector3 directionToTarget, float projectedDistance)
    {
        transform.position += directionToTarget * projectedDistance;
    }

    private Vector3 GetAngle(out Vector3 directionToTarget, out float projectedDistance)
    {
        Vector3 target2D = new(target.x, target.y, transform.position.z);
        directionToTarget = (target2D - transform.position).normalized;
        projectedDistance = projectileSpeed * Time.deltaTime;
        return target2D;
    }

    private void OnHit()
    {
        NabeDebug.Log("OnHit");

        Destroy(gameObject);
    }
}