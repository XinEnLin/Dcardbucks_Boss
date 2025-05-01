using UnityEngine;
using UnityEngine.Tilemaps; // 要有這行才能用 Tilemap
using System.Collections;

public class BuildingFade : MonoBehaviour
{
    private Tilemap tilemap;
    public float fadeAlpha = 0.5f; // 透明度（0~1）
    public float fadeDuration = 0.5f;  // 漸變持續時間（秒）
    private float originalAlpha;
    private Coroutine fadeCoroutine;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        if (tilemap == null)
        {
            Debug.LogError("Tilemap not found on this GameObject!");
        }
        else
        {
            originalAlpha = tilemap.color.a;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            fadeCoroutine = StartCoroutine(FadeToAlpha(fadeAlpha));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            fadeCoroutine = StartCoroutine(FadeToAlpha(originalAlpha));
        }
    }

    private IEnumerator FadeToAlpha(float targetAlpha)
    {
        Color color = tilemap.color;
        float startAlpha = color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / fadeDuration);
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            color.a = newAlpha;
            tilemap.color = color;

            yield return null;
        }

        // 保證最後透明度精確到達目標值
        color.a = targetAlpha;
        tilemap.color = color;
    }
}
