using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class BuildingFade : MonoBehaviour
{
    private Tilemap tilemap;

    public float fadeAlpha = 0f;
    public float fadeDuration = 0.5f;

    private float originalAlpha;
    private Coroutine fadeCoroutine;

    public Transform playerTransform; // 👈 需手動指派玩家

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

    private void Update()
    {
        if (playerTransform == null) return;

        Vector3 playerWorldPos = playerTransform.position;
        Vector3Int playerCellPos = tilemap.WorldToCell(playerWorldPos);

        TileBase currentTile = tilemap.GetTile(playerCellPos);

        if (currentTile != null)
        {
            if (fadeCoroutine == null)
            {
                fadeCoroutine = StartCoroutine(FadeToAlpha(fadeAlpha));
            }
        }
        else
        {
            if (fadeCoroutine == null && tilemap.color.a < originalAlpha)
            {
                fadeCoroutine = StartCoroutine(FadeToAlpha(originalAlpha));
            }
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

        color.a = targetAlpha;
        tilemap.color = color;
        fadeCoroutine = null;
    }
}

