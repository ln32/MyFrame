using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderTrigger : MonoBehaviour, IEventChecker
{
    [SerializeField] private SkillHitContainer skillHitContainer;
    private Collider2D _col;

    private void Start()
    {
        _col = GetComponent<Collider2D>();
        skillHitContainer.EventChecker = this;
    }

    public bool Check(Vector2 position)
    {
        return _col.OverlapPoint(position);
    }
}