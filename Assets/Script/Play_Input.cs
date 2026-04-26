using Cat;
using System.Collections;
using UnityEngine;
using Spine.Unity;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Cat;
#region 主角旗標
public struct InputCommand
{
    // ===== 狀態 =====
    public float moveX;
    public float moveZ;

    public bool run;
    public bool jump;

    public bool attack;
    public bool sweep;

    public bool rollForward;

    public bool crouch;
    public bool heavy;

    public void ClearOneShot()
    {
        attack = false;
        sweep = false;
        rollForward = false;
        heavy = false;
    }
}
#endregion




public class Play_Input: MonoBehaviour
{
    // ===== 移動 =====
    public float Run_Speed = 5.0f;
     // ===== 跳躍 =====
    public float jump_high = 2f;
    public float jump_speed;
    // ===== 狀態 =====
    public InputCommand Input;

    public Rigidbody2D Cat_Rig;
    // ===== Input =====
    // ===== Component =====
    //public Rigidbody myrigi; // 新增此欄位
    private void Awake()
    {
    Cat_Rig = GetComponent<Rigidbody2D>();
    // model = transform.GetChild(0);
    }

    private void Update()
    {
        float rawX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float rawZ = UnityEngine.Input.GetAxisRaw("Vertical");
        Input.moveX =rawX;
        Input.moveZ = rawZ;
        
        // In this simple implementation, "running" is defined as holding any horizontal input.
        Input.run = Mathf.Abs(rawX) > 0.0f;

        // You can extend these if you decide to support jumping or attacking later.
        //Input.jump = UnityEngine.Input.GetKeyDown(KeyCode.Space);
        //Input.attack = UnityEngine.Input.GetMouseButtonDown(0);
    }

    public void turn(float duration)
    {
        float angle = duration == +1 ? 90 : 270;

        //角度=角度插值(目前角度,目標角度,時間*轉速)
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * turn_speed);

    }
    public void setv(Vector2 velocity)
    {
        // Debug.Log("setv called: " + velocity);
        Cat_Rig.linearVelocity = velocity;
        //   Debug.Log("after setv rb vel: " + myrigi.linearVelocity);
    }


}
