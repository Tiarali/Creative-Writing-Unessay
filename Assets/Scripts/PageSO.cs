using UnityEngine;

[CreateAssetMenu(menuName = "Story Page", fileName = "New Page")]
public class PageSO : ScriptableObject
{
    [SerializeField] [TextArea(5, 15)] string page = "Type info about Jessica Townsend here!";


    public string GetPage()
    {
        return page;
    }
}
