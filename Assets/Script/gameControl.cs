using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Dialog, Battle }
public class gameControl : MonoBehaviour
{
    [SerializeField] player_control player_Control;

    GameState state;

    private void Start()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Additive);

        DialogManager.instance.OnShowDialog += () =>//當 DialogManager 發出「要顯示對話」的通知時，就把遊戲狀態 state 改成 GameState.Dialog。
        {
            state = GameState.Dialog;
        };
        DialogManager.instance.OnHideDialog += () =>
        {
            if(state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            player_Control.HandleUpdate();

        }
        else if (state == GameState.Dialog)
        {
            DialogManager.instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {

        }
    }
}
