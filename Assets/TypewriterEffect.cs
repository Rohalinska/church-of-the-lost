using System.Collections;
using UnityEngine;
using TMPro; // ÂÀÆËÈÂÎ!

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text storyText; // çàì³ñòü Text

    [TextArea]
    public string fullText;

    public float typingSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        storyText.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}