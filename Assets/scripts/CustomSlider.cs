using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomSlider : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Image fillImage;  // Assign your fillable image
    public RectTransform handle; // Assign your handle image
    public float minX, maxX; // Set the min and max X positions for handle movement
    private float fillAmount;

    void Start()
    {
        fillAmount = fillImage.fillAmount;
        UpdateHandlePosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = handle.position;
        newPos.x = Mathf.Clamp(eventData.position.x, minX, maxX);
        handle.position = newPos;

        // Convert handle position to fill amount
        fillAmount = (handle.position.x - minX) / (maxX - minX);
        fillImage.fillAmount = fillAmount;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); // Allow clicking on the bar to move the handle
    }

    void UpdateHandlePosition()
    {
        float handleX = Mathf.Lerp(minX, maxX, fillAmount);
        handle.position = new Vector3(handleX, handle.position.y, handle.position.z);
    }
}
