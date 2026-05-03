using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cat
{
    public class audio_manage : MonoBehaviour
    {
        public AudioClip Mouse_Move;
        public AudioClip Click;
        public AudioClip Figjt1;
        public AudioClip Fight2;
        public AudioClip BGM_1;
        public AudioClip BGM_2;
        //public AudioClip Hurt;
        //public AudioClip Lose;
        //public AudioClip Win;
        List<AudioSource> audios = new(); // 使用簡化的 new 運算式
        void Awake()
        {
            for (int i = 0; i < 10; i++)
            {
                //audios.Add(gameObject.AddComponent<AudioSource>());
                var audio = this.gameObject.AddComponent<AudioSource>();
                audios.Add(audio);

            }
           // play(4, "場景1_BGM", true);
        }
        public void play(int index, string name, bool isloop,float Volume)
        {
            var clip = getaudioclip(name);
            Debug.Log("播放音效: " + name);
            if (clip != null && index >= 0 && index < audios.Count)
            {
                var audio = audios[index];
                audio.clip = clip;
                audio.volume = Volume; // ⭐ 調整音量TEST
                audio.loop = isloop;
                audio.Play();
            }

        }
        public void Stop(int index)
        {
            if (index >= 0 && index < audios.Count)
            {
                audios[index].Stop();
            }
        }
        AudioClip getaudioclip(string name)
        {
            switch (name)
            {
                case "滑鼠移動":
                    return Mouse_Move;
                case "點擊":
                    return Click;
                case "打1":
                    return Figjt1;
                case "打3":
                    return Fight2;
                case "場景1_BGM":
                    return BGM_1;
                case "level1_music":
                    return BGM_2;
                default:
                    return null;
            }
        }

        
    }
}
