using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{

    [Header("Components")]
    public GameObject dialogObject; // The main dialog box
    public Image profileImage; // The image displayed in the dialog
    public Text dialogText; // The text content of the dialog
    public Text nameText; // The name of the character speaking

    [Header("Settings")]
    public float typingSpeed = 0.05f;
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
    }

    public void NextSentence()
    {
        if (index < dialogLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogObject.SetActive(false);
        }
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
