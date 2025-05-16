using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class GPTDialog : MonoBehaviour
{
    public string apiKey = "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"; // 填入你的 GPT API 金鑰
    public string npcPrompt = "你是村莊裡一位和善的老人，會回答旅人的問題。";

    public IEnumerator GetResponseFromGPT(string userMessage, System.Action<string> callback)
    {
        string url = "https://api.openai.com/v1/chat/completions";

        string jsonBody = @"{
            ""model"": ""gpt-3.5-turbo"",
            ""messages"": [
                {""role"": ""system"", ""content"": """ + npcPrompt + @"""},
                {""role"": ""user"", ""content"": """ + userMessage + @"""}
            ]
        }";

        UnityWebRequest request = new UnityWebRequest(url, "POST"); 
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string result = request.downloadHandler.text;

            try
            {
                GPTResponse response = JsonUtility.FromJson<GPTResponse>(result);
                string reply = response.choices[0].message.content;
                Debug.Log("✅ GPT 真實回應內容：" + reply);
                callback?.Invoke(reply);
            }
            catch
            {
                Debug.LogError("❌ 無法解析 GPT 回應，原始文字如下：\n" + result);
                callback?.Invoke("⚠️ 無法解析 GPT 回應。");
            }

        }
        else
        {
            callback?.Invoke("⚠️ 請求失敗：" + request.error + "\n" + request.downloadHandler.text);

        }
    }
}
[System.Serializable]
public class GPTResponse
{
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}
