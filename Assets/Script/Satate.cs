using UnityEngine;

public class State
{
    public virtual void Enter()
    {
        // 進入狀態時的邏輯
    }


    public virtual void GameLogic()
    {
        // 狀態執行時的邏輯
    }
    public virtual void PalyLogic()
    {
        // 玩邏輯
    }
    public virtual void Exit()
    {
        // 離開狀態時的邏輯
    }

}
