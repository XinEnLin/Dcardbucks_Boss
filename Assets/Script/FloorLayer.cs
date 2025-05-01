using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorLayer : MonoBehaviour
{
    public TilemapRenderer[] renderers;         // 控制畫面
    public TilemapCollider2D[] colliders;       // 控制碰撞

    public bool defaultVisible = false; // ✅ 新增欄位：預設是否顯示

    private void Start()
    {
        SetEnable(defaultVisible); // 🚀 執行預設顯示狀態
    }
    public void SetEnable(bool visible)
    {
        foreach (var r in renderers)
        {
            r.enabled = visible;
        }

        foreach (var c in colliders)
        {
            Debug.Log($"{name} Collider Enabled 設為 {visible}：{c.gameObject.name}");
            c.enabled = visible;
        }
    }
}
