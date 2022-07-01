using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public static float volume = 1f;


    void Start()
    {
        transform.GetComponent<Scrollbar>().value = volume;
    }

    void Update()
    {
        AudioListener.volume = transform.GetComponent<Scrollbar>().value;
        volume = transform.GetComponent<Scrollbar>().value;
    }
}
