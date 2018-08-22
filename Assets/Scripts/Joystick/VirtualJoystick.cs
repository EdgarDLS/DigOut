using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Image joystickImage;

    public Vector3 InputDirection { set; get; }

    void Start()
    {
        backgroundImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / backgroundImage.rectTransform.sizeDelta.x);
            position.y = (position.y / backgroundImage.rectTransform.sizeDelta.y);

            float x = (backgroundImage.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (backgroundImage.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;


            joystickImage.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * (backgroundImage.rectTransform.sizeDelta.x / 3), InputDirection.z * (backgroundImage.rectTransform.sizeDelta.y / 3));

            //Debug.Log(InputDirection);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
}
