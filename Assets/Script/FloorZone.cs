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
                floor.SetEnable(floor == currentFloor);
                Debug.Log("�����Ӽh��G" + currentFloor.gameObject.name);

            }
        }
    }
}
    