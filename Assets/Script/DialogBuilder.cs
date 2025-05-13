using System.Collections.Generic;
using UnityEngine;

public class DialogBuilder
{
    private List<string> lines = new List<string>();
    public DialogBuilder AddLine(string line)
    {
        lines.Add(line);
        return this;
    }

    public Dialog Build()
    {
        Dialog dialog = ScriptableObject.CreateInstance<Dialog>();
        dialog.SetLines(lines);
        return dialog;

    }
}

