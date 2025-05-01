using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle }
public class gameControl : MonoBehaviour
{
    [SerializeField] player_control player_Control;

    GameState state;

    private void Start()
    {
        DialogManager.instance.OnShowDialog += () =>//�� DialogManager �o�X�u�n��ܹ�ܡv���q���ɡA�N��C�����A state �令 GameState.Dialog�C
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
