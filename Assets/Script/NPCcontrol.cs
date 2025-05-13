using System.Collections;
using UnityEngine;

public class NPCcontrol : MonoBehaviour, interactable
{
    [SerializeField] string characterName = "莉亞";  // 對應 JSON 中角色
    [TextArea]
    public string defaultUserInput = "最近村子裡有什麼事？";  // 你想問的話

    [TextArea]
    public string openingLine = "你好，歡迎來到村子！"; // 固定開場白

    OllamaDialog ollama;

    private void Awake()
    {
        ollama = gameObject.AddComponent<OllamaDialog>();
        ollama.characterName = characterName;
    }

    public void Interact()
    {
        // 第一步：顯示固定開場白
        Dialog dialog = new DialogBuilder().AddLine(openingLine).Build();
        Debug.Log("👋 開場白：" + openingLine);
        StartCoroutine(ShowOpeningAndThenAsk(dialog));
    }

    private IEnumerator ShowOpeningAndThenAsk(Dialog opening)
    {
        yield return DialogManager.instance.ShowDialog(opening);

        // 第二步：顯示 AI 回覆（根據 defaultUserInput）
        yield return new WaitForSeconds(0.5f); // 可加點停頓感

        ollama.GetResponse(defaultUserInput, (reply) =>
        {
            Dialog dialog = new DialogBuilder().AddLine(reply).Build();
            Debug.Log("🧠 AI 回覆：" + reply);
            StartCoroutine(DialogManager.instance.ShowDialog(dialog));
        });
    }
}
