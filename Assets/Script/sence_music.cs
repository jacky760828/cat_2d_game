using Cat;
using UnityEngine;

public class sence_music : MonoBehaviour
{
    void Start()
    {
        Game_Manager.Instance.Audio?.play(5, "level1_music", true, 0.3f);
    }
}
