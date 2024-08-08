using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    public bool IsHit(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            if (hit.collider.CompareTag(Tag.Obstacle))
                return true;
        }

        return false;
    }
}