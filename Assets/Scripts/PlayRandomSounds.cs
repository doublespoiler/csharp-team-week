// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayRandomSounds : MonoBehaviour
// {

//     public AudioSource gun_Audio;

//     [field: SerializeField]
//     public AudioClip[] AudioClipArray;

//     void Awake()
//     {
//         gun_Audio = GetComponent<AudioSource>();
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         gun_Audio.clip = AudioClipArray[Random.Range(0, AudioClipArray.length)];
//         gun_Audio.PlayOneShot(gun_Audio.clip);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
