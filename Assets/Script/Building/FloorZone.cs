using UnityEngine;

public class FloorZone : MonoBehaviour
{
    public FloorLayer[] allFloors;
    public FloorLayer currentFloor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (var floor in allFloors)
            {
                floor.SetVisible(floor == currentFloor);
                Debug.Log("¤w¤Á´«¦Ü¼Ó¼h¡G" + currentFloor.gameObject.name);
            }
        }
    }
}
