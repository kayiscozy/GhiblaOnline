using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public GameObject dialogBox; // Das UI-Element für den Dialog
    public Text dialogText; // Textfeld für den Dialog
    private string[] dialogLines;
    private int currentLine = 0;
    private bool isTalking = false;

    public void StartDialog(string[] lines)
    {
        dialogLines = lines;
        currentLine = 0;
        dialogBox.SetActive(true);
        isTalking = true;
        ShowNextLine();
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
            currentLine++;
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        dialogBox.SetActive(false);
        isTalking = false;
    }
}