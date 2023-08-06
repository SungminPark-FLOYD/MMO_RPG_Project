using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        //인벤토리 만들기
        Managers.UI.ShowSceneUI<UI_Inven>();

        //Data 가져오기
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        //커서 컴포넌트 추가
        gameObject.GetOrAddComponent<CursorController>();

        //오브젝트 추가
        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        //플레이어 카메라 설정
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        //Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);

        /* UIManager 실습
        //ui생성
        //Managers.UI.ShowPopupUI<UI_Button>("UI_Button");
        //삭제
        //ver1
        //Managers.UI.ClosePopupUI();
        //ver2
        //Managers.UI.ClosePopupUI(ui);
        */


    }

    public override void Clear()
    {

    }
}

/* Coroutine은 함수의 상태를 저장/복원 가능
 *  -> 엄청 오래 걸리는 작업을 잠시 끊거나
 *  -> 원하는 타이밍에 함수를 잠시 Stop/복원하는 경우
 *  -> return은 우리가 원하는 타입으로도 가능하다
 *  -> Coroutine 타입으로 저장 가능
 */
