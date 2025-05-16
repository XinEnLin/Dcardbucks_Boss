# 🏡 Dcardbucks - 2D Pixel RPG 專案

## 🎯 專案簡介
本專案是一款以 2D 像素風格製作的 RPG 小遊戲，玩家可以在村莊中自由移動、與 NPC 互動、體驗來自 Dcard 留言創建的人物故事。

## 🎮 遊戲玩法
- 使用方向鍵移動角色（上下左右單一方向）
- 按 `Z` 鍵與 NPC 互動開啟對話
- 進入建築物門口，建築會自動透明化
- 支援地圖自動遮擋效果（頭擋腳）
- 對話系統支援打字動畫效果

## 🛠️ 開發技術與工具
- **Unity** 2021 / 2022
- **C#**
- **2D Tilemap 系統**（地圖拼接）
- **Rigidbody2D + Collider2D**（角色移動與碰撞）
- **事件系統**（DialogManager 控制遊戲狀態）
- **Coroutine**（實現透明度漸變效果）

## 📂 專案結構（重要資料夾）
- `Assets/Scripts/`：所有自製 C# 腳本
- `Assets/Tilemaps/`：場景地圖資源
- `Assets/Sprites/`：角色與物件圖片
- `Assets/Scenes/`：Unity 場景檔案

## 📦 開發紀錄（Changelog）

### 2025-04-29
- 玩家移動系統
- 建築物透明化
- NPC 對話系統
- 基礎地圖遮擋系統

### 2025-05-04
- 加入NPC對話系統
- 建立成就蒐集系統

### 2025-05-12
- 怪物：蟲蟲、哥布林

## 📖 安裝與執行
1. 下載本專案或 Clone 下來
2. 使用 Unity Hub 打開
3. 直接開啟 `Assets/Scenes/MainScene.unity`
4. 按 `Play` 開始遊戲

## 🙏 特別感謝
- 感謝 OpenGameArt.org 提供免費像素資源
- 參考 YouTube 教學影片《Unity 2D RPG 系列》
- 使用 Unity 官方文檔資料學習 Tilemap、Collider 系統

---
