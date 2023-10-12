using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    [SerializeField]
    private PlayerReversi up;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> ();
    }

    public void Flip()
    {
        if(up == PlayerReversi.Black)
        {
            animator.Play("BlackToWhite");
            up = PlayerReversi.White;
        }
        else
        {
            animator.Play("WhiteToBlack");
            up = PlayerReversi.Black;
        }
    }

    public void Twitch()
    {
        animator.Play("TwitchDisc");
    }
}
