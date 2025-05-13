using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject phonePanel;
    public TMP_InputField playerInput;
    public TMP_Text npcResponseText;
    public OllamaDialog ollamaDialog;

    private bool isPhoneVisible = false;

    private void Start()
    {
        playerInput.onSubmit.AddListener(HandleSubmit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isPhoneVisible = !isPhoneVisible;
            phonePanel.SetActive(isPhoneVisible);

            if (isPhoneVisible)
            {
                playerInput.text = "";
                playerInput.ActivateInputField();
            }
        }
    }

    private void HandleSubmit(string text)
    {
        SendMessageToNPC();
    }

    void SendMessageToNPC()
    {
        string message = playerInput.text.Trim();
        if (string.IsNullOrEmpty(message)) return;

        npcResponseText.text = "（等待回應中...）";

        ollamaDialog.GetResponse(message, response =>
        {
            npcResponseText.text = response;
        });

        playerInput.text = "";
        playerInput.ActivateInputField();
    }
}
