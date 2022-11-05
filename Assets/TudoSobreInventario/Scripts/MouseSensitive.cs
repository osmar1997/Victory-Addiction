using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSensitive : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static event System.Action<string, string> MouseON;
    public static event System.Action MouseOFF;
    public static event System.Action<Item> IsClicked;
    private ItemReference reference;
    
    void Start()
    {
        reference= GetComponent<ItemReference>();
        ChangeColor(Color.gray);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        IsClicked?.Invoke(reference._Item);
        reference.UpdateCount();
        if(reference._Item.Count==0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor(Color.white);
        MouseON?.Invoke(reference._Item.Name, reference._Item.Description);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeColor(Color.gray); ;
        MouseOFF?.Invoke();
    }
    private void ChangeColor(Color _color) => reference.Icon.color = _color;
}
