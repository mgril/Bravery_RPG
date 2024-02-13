using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSound : MonoBehaviour
{
    [SerializeField] private int SFXAreaSoundIndex;
    [SerializeField] private int BGMAreaSoundIndex;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (SFXAreaSoundIndex > 0)
                AudioManager.instance.PlaySFX(SFXAreaSoundIndex, null);
            if (BGMAreaSoundIndex > 0)
            {
                AudioManager.instance.PlayBGM(BGMAreaSoundIndex);
            }

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (SFXAreaSoundIndex > 0)
                AudioManager.instance.StopSFXWithTime(SFXAreaSoundIndex);

        }

    }
}
