using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slotsTargetCanvas;
    private List<GameObject> gameObjectsInSlots = new List<GameObject>(9);

    public void AddPrefabInSlot(GameObject prefab, int index)
    {
        gameObjectsInSlots.Insert(index,prefab);
    }

    public GameObject GetPrefabByIndex(int index)
    {
        return gameObjectsInSlots[index];
    }

    public void DeletePrefabByIndex(int index)
    {
        gameObjectsInSlots[index] = null;
    }
}
