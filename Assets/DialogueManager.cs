using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class DialogueNode
{
    public string text;
    public string choice1;
    public string choice2;
    public string choice3;

    public int next1;
    public int next2;
    public int next3;
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public Button btn1, btn2, btn3;
    public TextMeshProUGUI btn1Text, btn2Text, btn3Text;

    public DialogueNode[] nodes;

    int currentNode = 0;
    int karma = 0;

    void Start()
    {
        ShowNode();
    }

    public void Choose(int choice)
    {
        if (choice == 1) karma++;
        if (choice == 3) karma--;

        var node = nodes[currentNode];

        if (choice == 1) currentNode = node.next1;
        if (choice == 2) currentNode = node.next2;
        if (choice == 3) currentNode = node.next3;

        ShowNode();
    }

    void ShowNode()
    {
        var node = nodes[currentNode];

        if (currentNode == 2) // �����
        {
            if (karma >= 2)
                dialogueText.text = node.text + "\n\n����� �����...\n� �� ������� ����...";
            else if (karma <= -2)
                dialogueText.text = node.text + "\n\n� ����� ���� �����, ����.";
            else
                dialogueText.text = node.text + "\n\n���� ������ ����.";

            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
            btn3.gameObject.SetActive(false);
            return;
        }

        dialogueText.text = node.text;

        btn1Text.text = node.choice1;
        btn2Text.text = node.choice2;
        btn3Text.text = node.choice3;
    }
}
