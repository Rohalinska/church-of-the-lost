using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public GameObject nextButton;

    public string[] texts;
    private int index = 0;

    public float typingSpeed = 0.05f;

    void Start()
    {
        nextButton.SetActive(false);
        StartCoroutine(TypeText());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextText();
        }
    }

    IEnumerator TypeText()
    {
        storyText.text = "";

        foreach (char letter in texts[index])
        {
            storyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
    }

    public void NextText()
    {
        index++;

        if (index < texts.Length)
        {
            nextButton.SetActive(false);
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
    }
}