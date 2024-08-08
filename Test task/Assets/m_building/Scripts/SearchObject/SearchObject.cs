using UnityEngine;

public class SearchObject : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public GameObject GetObject(float range, string tag)
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, range);

        GameObject target = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                float distance = Vector3.Distance(_transform.position, collider.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    target = collider.gameObject;
                }
            }
        }
        return target;
    }
}