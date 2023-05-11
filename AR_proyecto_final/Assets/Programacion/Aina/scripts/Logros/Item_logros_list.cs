using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_logros_list : MonoBehaviour
{
    public string songName;
    public AudioClip audioClip;

    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = songName;
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(PlaySound);
        gameObject.GetComponent<Button>().onClick.AddListener(Refresh_Selected_Sound);
    }

    private void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
    
    private void Refresh_Selected_Sound()
    {
        //Custom_Manager.instance.RefreshSelectedSoundTxt(songName);
        //UI_Manager.instance.SelectSoundEdit(songName);
    }
}
