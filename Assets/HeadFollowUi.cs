using UnityEngine;
//  test github
public class HeadFollowUI : MonoBehaviour
{
    public Transform head;     
    public float distance = 2f;
    public float smoothSpeed = 6f;

    public Transform head;              // CenterEyeAnchor
//     public float distance = 0.6f;       // Distance plus proche (poke friendly)
    public float heightOffset = -0.05f; // Légèrement sous les yeux
//     public float smoothSpeed = 8f;      // Plus fluide

    void LateUpdate()
    {
        if (head == null) return;

        // Position cible EXACTEMENT devant la tête

        // Direction complète (inclut vertical maintenant)
        Vector3 targetPosition = head.position + head.forward * distance;
        targetPosition.y += heightOffset;

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
        // Toujours regarder la tête correctement
        transform.LookAt(head);

        // Rotation 180° pour que le canvas fasse face à l'utilisateur
        transform.Rotate(0, 180f, 0);
    }
}