using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public AudioClip shotSound;
    private AudioSource _audio;

    public bool isPrimary = true;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
 if ((isPrimary && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            || (!isPrimary && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))) {
            _audio.PlayOneShot(shotSound);
            Instantiate(bullet, firePos.position, firePos.rotation);
            OVRInput.SetControllerVibration(0.3f, 0.2f);
        }
    }
}