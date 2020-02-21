using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // created using https://youtu.be/_nRzoTzeyxU as a guide
    public string name;

    [TextArea(3, 15)]
    public string[] sentences;

}
