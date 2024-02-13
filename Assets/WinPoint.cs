using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    private Animator anim;

    public bool activationStatus;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>() != null)
        {
            ActivateWinpoint();
        }
    }
    public void ActivateWinpoint()
    {
        anim.SetBool("active", true);
        GameObject.Find("Canvas").GetComponent<UI>().SwitchOnNextLevelScreen();

    }
}
