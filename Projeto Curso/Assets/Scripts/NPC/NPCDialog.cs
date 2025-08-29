using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public float dialogRadius = 1f;
    private LayerMask playerLayer;
    bool playerInRange = false;
    public DialogSettings dialogSettings;
    private List<string> dialogLines = new List<string>();

    void Awake()
    {
        playerLayer = LayerMask.GetMask("Player");
        GetNPCDialogLines();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogControl.instance.Speech(dialogLines.ToArray());
        }
    }

    void GetNPCDialogLines()
    {
        for (int i = 0; i < dialogSettings.dialogues.Count; i++)
        {
            dialogLines.Add(dialogSettings.dialogues[i].setence.portuguese);
        }
    }

    void FixedUpdate()
    {
        CheckPlayerInRange();
    }

    void CheckPlayerInRange()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, dialogRadius, playerLayer);
        if (hitCollider != null)
        {
            playerInRange = true;
            return;
        }
        playerInRange = false;
        DialogControl.instance.dialogObject.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, dialogRadius);
    }
}
