using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Transform trans;

    public bool Check(Vector2 position)
    {
        return Vector2.Distance(trans.position, position) < range;
    }
}