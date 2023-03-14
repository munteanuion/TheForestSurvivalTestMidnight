using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public bool[] isFull;
    public GameObject[] slotsTargetCanvas;
    public List<GameObject> gameObjectsInSlots = new List<GameObject>(3);

    private void Awake()
    {
        Instance = this;
    }

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

    public int GetLenghtGameObjectsInSlots()
    {
        return gameObjectsInSlots.Count;
    }
}
