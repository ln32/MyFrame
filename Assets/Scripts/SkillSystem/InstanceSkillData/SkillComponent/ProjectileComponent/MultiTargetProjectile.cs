using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MultiTargetProjectile : CastVisualComponent
{
    private Collider2D _col;
    private ITargetingRule _rule;
    private readonly HashSet<Vector3> _skillHitContainer = new();

    private void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;

        if (_rule == null)
        {
            return;
        }

        foreach (Vector3 pointV3 in _rule.GetPositionsFromObjects())
        {
            if (_skillHitContainer.Contains(pointV3))
                continue;

            if (_col.OverlapPoint(pointV3))
            {
                _skillHitContainer.TryAddObject(pointV3);
                onHit?.Invoke(pointV3);
            }
        }

        if (reachTime == 0 || reachTime < lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.Lerp(srcV3, dstV3, lifeTime / reachTime);
        }
    }

    public void InitValue(ITargetingRule rule)
    {
        _rule = rule;
    }
}