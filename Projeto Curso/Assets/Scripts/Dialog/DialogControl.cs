using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject dialogObject; // The main dialog box
    public Image profileImage; // The image displayed in the dialog
    public TextMeshProUGUI dialogText; // The text content of the dialog
    public Text nameText; // The name of the character speaking

    [Header("Settings")]
    public float typingSpeed;
    private bool isShowing = false;
    private int index;
    private string[] dialogLines;

    public static DialogControl instance;

    void Awake()
    {
        instance = this;
    }

    IEnumerator TypeLine()
    {
        dialogText.text = "";
        foreach (char letter in dialogLines[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1f);
        NextSentence();
    }

    public void NextSentence()
    {
        if (index < dialogLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
            return;
        }
        DisableDialog();
    }

    public void DisableDialog()
    {
        dialogObject.SetActive(false);
        isShowing = false;
        index = 0;

    }

    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogObject.SetActive(true);
            dialogLines = txt;
            StartCoroutine(TypeLine());
            isShowing = true;
        }
    }

}
