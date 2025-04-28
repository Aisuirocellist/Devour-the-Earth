using System.Collections.Generic;
using UnityEngine;

public class ListWatcherDebug : MonoBehaviour
{
    public List<Assimilation.ShipData> collectedList;
    public List<Assimilation.ShipData> minionList;

    private void Start()
    {
        collectedList = new List<Assimilation.ShipData>(Assimilation.collectionList);
        minionList = new List<Assimilation.ShipData>(Assimilation.minionList);
    }
    void Update()
    {
        collectedList = new List<Assimilation.ShipData>(Assimilation.collectionList);
        minionList = new List<Assimilation.ShipData>(Assimilation.minionList);
    }
}
