using Cat;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    public Button btn_load;
    public Button btn_Start;
    public Button btn_Option;
    public Button btn_Quit;
    // public static loading_system instance;

    private void Awake()
    {
       
        Debug.Log("主選單");
        btn_Start.onClick.AddListener(Start_Game);
    }

    private void Start()
    {
        Game_Manager.Instance.Audio?.play(4, "場景1_BGM", true,0.1f);
    }
    private void Start_Game()
    {
        Game_Manager.Instance.Audio.Stop(4);
        Fading_Fadout.instance.StartLoading("第一關");
       // _Statemachine.Audio?.play(0, "拳1", false);

        Debug.Log("轉場");
    }

    private void quit_game()
    {
        Application.Quit();
    }

  
}
