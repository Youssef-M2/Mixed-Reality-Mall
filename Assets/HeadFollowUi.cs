using UnityEngine;

public class HeadFollowUI : MonoBehaviour
{
    public Transform head;        // Drag CenterEyeAnchor ici
    public float distance = 2f;
    public float heightOffset = -0.2f;
    public float smoothSpeed = 6f;

    void LateUpdate()
    {
        if (head == null) return;

        // Position cible devant la tête
        Vector3 forward = head.forward;
        forward.y = 0; // Ignore inclinaison haut/bas

        Vector3 targetPosition = head.position + forward.normalized * distance;
        targetPosition.y += heightOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        // Regarder vers la tête (horizontalement)
        Vector3 lookDir = transform.position - head.position;
        lookDir.y = 0;

        if (lookDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(lookDir);
    }
}