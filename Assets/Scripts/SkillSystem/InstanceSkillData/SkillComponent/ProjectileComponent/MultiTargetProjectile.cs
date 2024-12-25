using UnityEngine;

public class MultiTargetProjectile : ProjectileComponent
{
    private Collider2D _col;
    private ITargetingRule _rule;
    private SkillHitContainer<Vector3> _skillHitContainer;

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
            if (_skillHitContainer.IsContain(pointV3))
            {
                continue;
            }

            if (_col.OverlapPoint(pointV3))
            {
                onHit?.Invoke(pointV3);

                _skillHitContainer.AddObject(pointV3);
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
        _skillHitContainer = new SkillHitContainer<Vector3>();
    }
}