using UnityEngine;

public class FloorLayer : MonoBehaviour
{
    public bool defaultVisible = false;

    private void Start()
    {
        gameObject.SetActive(defaultVisible);
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }
}
