using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject menuCursor;
    private GameObject spawnedCursor;

    private float buttonWidth;
    private float cursorWidth;

    void Awake()
    {
        buttonWidth = ((RectTransform)transform).rect.width;
        cursorWidth = ((RectTransform)menuCursor.transform).rect.width;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (spawnedCursor == null)
        {
            spawnedCursor = Instantiate(menuCursor, transform);
            float posX = -(buttonWidth / 2) - cursorWidth;
            ((RectTransform)spawnedCursor.transform).anchoredPosition = new Vector2(posX, 0);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Destroy(spawnedCursor);
    }
}
