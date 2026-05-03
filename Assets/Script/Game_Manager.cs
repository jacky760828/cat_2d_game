using Cat;
using UnityEngine;

namespace Cat
{
    public class Game_Manager : MonoBehaviour
    {
        public static Game_Manager Instance;//靜態方法

        public audio_manage Audio { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                InitManagers();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void InitManagers()
        {
            // 👉 把 audio_manage 掛在這個物件底下
            Audio = GetComponentInChildren<audio_manage>();

            if (Audio == null)
            {
                Debug.LogError("找不到 audio_manage！");
            }
        }
    }
}