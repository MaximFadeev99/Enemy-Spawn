using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public IEnumerator MoveToTarget(Vector3 targetPoint)
    {
        float coveredDistance = 0.005f;
        Vector2 viewDirection = (Vector2)targetPoint;

        transform.right = (Vector3)(viewDirection - new Vector2(transform.position.x, transform.position.y));
        
        while (transform.position != targetPoint)
        {
            transform.position = Vector3.Lerp(transform.position, targetPoint, coveredDistance);
            yield return null;
        }
    }
}
