using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderTrigger : MonoBehaviour
{
    private Collider2D _col;

    private void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    public bool Check(Vector2 position)
    {
        return _col.OverlapPoint(position);
    }
}