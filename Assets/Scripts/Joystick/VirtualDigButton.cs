using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualDigButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] Image backgroundImage;

    public bool drillOut;

    void Start()
    {
        backgroundImage = GetComponent<Image>();
        drillOut = false;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        drillOut = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        drillOut = false;
    }
}