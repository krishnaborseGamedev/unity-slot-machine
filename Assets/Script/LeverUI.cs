using UnityEngine;
using UnityEngine.EventSystems;

public class LeverUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float pulledRotation = -25f;
    public float returnSpeed = 15f;

    private Quaternion normalRotation;
    private Quaternion pulledRotationQuaternion;

    void Start()
    {
        normalRotation = transform.localRotation;

        pulledRotationQuaternion =
            Quaternion.Euler(0f, 0f, pulledRotation);
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            normalRotation,
            returnSpeed * Time.deltaTime
        );
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localRotation = pulledRotationQuaternion;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Update() automatically returns the lever.
    }
}