using System;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }


    #region Movement
    private void OnMove()
    {
        setMoveAnimation();
        setPlayerDirection();
  
    }

    private void setPlayerDirection()
    {
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void setMoveAnimation()
    {
        bool isMoving = player.direction.sqrMagnitude > 0;

        if (isMoving)
        {
            if (player.IsRolling)
            {
                anim.SetTrigger("isRolling");
                return;
            } else
            {
                anim.SetInteger("transition", 1);

                if (player.IsRunning)
                {
                    anim.SetInteger("transition", 2);
                };
            }  
        } else if (!isMoving)
        {
            anim.SetInteger("transition", 0);
        }
    }

    #endregion
}
