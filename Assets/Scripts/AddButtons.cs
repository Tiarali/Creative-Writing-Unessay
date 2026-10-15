using UnityEngine;
using System.Collections;

public class AddButtons : MonoBehaviour
{
    [SerializeField] Transform puzzleField;
    [SerializeField] GameObject btn;
    [SerializeField] int numButtons = 8;

    void Awake()
    {
        for (int i = 0; i < numButtons; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}
