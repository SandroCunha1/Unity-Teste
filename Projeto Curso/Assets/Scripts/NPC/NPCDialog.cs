using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public float dialogRadius = 1f;
    private LayerMask playerLayer;

    void Awake() {
        playerLayer = LayerMask.GetMask("Player");
    }

    void FixedUpdate()
    {
        ShowDialog();
    }

    void ShowDialog()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, dialogRadius, playerLayer);
        if (hitCollider != null)
        {
            Debug.Log("Player in range, show dialog");
            // Here you would call your dialog system to display the dialog
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, dialogRadius);
    }
}
