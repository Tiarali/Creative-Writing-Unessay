using UnityEngine;
using TMPro;


public class ChangeFont : MonoBehaviour
{
    [SerializeField] TMP_FontAsset curlyFont;
    [SerializeField] TMP_FontAsset plainFont;
    [SerializeField] float curlyFontSize;
    [SerializeField] float plainFontSize;
    

    TMP_Text text;
    Options options;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        options = GameObject.FindAnyObjectByType<Options>().GetComponent<Options>();

        

        //subscribe to event
        options.changeFont += ChooseFont;
    }

    void OnDestroy()
    {
        options.changeFont -= ChooseFont;

    }

    private void ChooseFont(bool isChanged)
    {
        
        if(isChanged)
        {
            text.font = plainFont;
            text.fontSize = plainFontSize;
        }
        else
        {
            text.font = curlyFont;
            text.fontSize = curlyFontSize;
            
        }
    }

    
}
