using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

[System.Serializable]
public class ChatRequest
{
    public string character;
    public string message;
}

[System.Serializable]
public class ChatResponse
{
    public string response;
}

public class OllamaDialog : MonoBehaviour
{
    [Header("設定")]
    public string characterName = "莉亞";  // JSON 對應角色
    public string apiUrl = "http://127.0.0.1:5000/api/chat";//自己的
    //public string apiUrl = "http://172.16.91.201:5000/";//威岑的


    public void GetResponse(string userInput, System.Action<string> onReply)
    {
        StartCoroutine(SendChat(characterName, userInput, onReply));
    }

    IEnumerator SendChat(string character, string message, System.Action<string> onReply)
    {
        ChatRequest requestData = new ChatRequest
        {
            character = character,
            message = message
        };

        string json = JsonUtility.ToJson(requestData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest www = new UnityWebRequest(apiUrl, "POST");
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string responseJson = www.downloadHandler.text;
            ChatResponse res = JsonUtility.FromJson<ChatResponse>(responseJson);
            Debug.Log("🧠 NPC 回應：" + res.response);
            onReply?.Invoke(res.response);
        }
        else
        {
            Debug.LogError("❌ 傳送失敗：" + www.error + "\n" + www.downloadHandler.text);
            onReply?.Invoke("（發送失敗）");
        }
    }
}
