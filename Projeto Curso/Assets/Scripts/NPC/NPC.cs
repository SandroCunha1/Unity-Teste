using UnityEngine;
using System.Collections.Generic;

public class NPC : MonoBehaviour
{
    private Animator anim;
    public float speed;
    private float originalSpeed;
    private int index;
    public List<Transform> paths = new List<Transform>();

    void Awake()
    {
        originalSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(DialogControl.instance.IsShowing)
        {
            speed = 0;
            anim.SetBool("isWalking", false);
        } else
        {
            speed = originalSpeed;
            anim.SetBool("isWalking", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        SetMoveAnimation();

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
           if(index < paths.Count - 1)
           {
               index++;
           }
           else
           {
               index = 0;
           }
        }
    }

    private void SetMoveAnimation()
    {
        if (transform.position.x < paths[index].position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (transform.position.x > paths[index].position.x)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
