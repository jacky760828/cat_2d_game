using Cat;
using UnityEngine;
// 請確認 GameManager 的命名空間，若 GameManager 定義於其他命名空間，請加上 using 對應命名空間
// 例如：using YourGameNamespace;

public class Attack_Small : State
{
    Animator anim;
    Play_Input pi;
    Cat_State_Machime _State_Machime;
    string Name;
    float timer = 0f;
    float attackDuration = 0.3f; // ⭐ 攻擊時間（依動畫長度調整）

    public Attack_Small(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
    {
        this.anim = anim;
        this.pi = pi;
        this._State_Machime = state_Machime;
        this.Name = name;
    }

    public override void Enter()
    {
        // Debug.Log("攻擊1");
        anim.SetBool("攻擊1", true);
        Game_Manager.Instance.Audio?.play(2, "打1", false,1f);
        // 若 GameManager 未定義於本檔案，請確認已正確引用其命名空間
        //  Game_Manager.Instance.Audio?.play(0, "打1", false);
        timer = 0f;
    }

    public override void GameLogic()
    {
        timer += Time.deltaTime;
        
        // ⭐ 攻擊結束
         if (timer >= attackDuration)
        {
            anim.SetBool("攻擊1", false);
            Debug.Log("攻擊結束，回Idle或Run");
            // 判斷回哪個狀態
            if (Mathf.Abs(pi.Input.moveX) > 0.1f)
                _State_Machime.changeto(_State_Machime._run);
            else
                _State_Machime.changeto(_State_Machime._idle);
        }
    }

    public override void PalyLogic()
    {
        // 攻擊時不移動（可改成慢速移動）
        float vy = pi.Cat_Rig.linearVelocity.y;
        pi.setv(new Vector2(0, vy));
    }

    public override void Exit()
    {
       // pi.Input.attack = false;
        anim.SetBool("攻擊1",false);
    }
}
