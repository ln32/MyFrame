using UnityEngine;

public class PointTrigger : MonoBehaviour, IEventChecker
{
    [SerializeField] private SkillHitContainer skillHitContainer;
    [SerializeField] private float range;
    [SerializeField] private Transform trans;

    private void Start()
    {
        skillHitContainer.EventChecker = this;
    }

    public bool Check(Vector2 position)
    {
        return Vector2.Distance(trans.position, position) < range;
    }
}