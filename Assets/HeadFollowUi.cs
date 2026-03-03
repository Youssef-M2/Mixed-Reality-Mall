using UnityEngine;
//  test github
public class HeadFollowUI : MonoBehaviour
{
    public Transform head;     
    public float distance = 2f;
    public float smoothSpeed = 6f;

    void LateUpdate()
    {
        if (head == null) return;

        // Position cible EXACTEMENT devant la tête
        Vector3 targetPosition = head.position + head.forward * distance;

        // Mouvement fluide
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        // Rotation complète (inclut haut / bas)
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            head.rotation,
            smoothSpeed * Time.deltaTime
        );
    }
}