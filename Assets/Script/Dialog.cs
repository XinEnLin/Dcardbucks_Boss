using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] List<string> lines = new List<string>();

    public List<string> Lines => lines;

    public void SetLines(List<string> newLines)
    {
        lines = newLines;
    }
}
