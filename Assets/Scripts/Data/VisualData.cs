using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Create VisualData", fileName = "New VisualData")]
public class VisualData : ScriptableObject
{
    public Sprite[] up;
    public Sprite[] right;
    public Sprite[] down;
    public Sprite[] left;

    public Sprite[] GetSpritesByDirection(int direction)
    {
        return direction switch
        {
            0 => up,
            1 => right,
            2 => down,
            _ => left
        };
    }
}
