using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlock : MonoBehaviour
{
    private bool moved = false;

    public void Toggle()
    {
        moved = !moved;

        Vector2 oldPosition = transform.position;

        if (moved)
        {
            transform.position = new Vector2(oldPosition.x, oldPosition.y + 2);
        }
        else
        {
            transform.position = new Vector2(oldPosition.x, oldPosition.y - 2);
        }
    }
}
