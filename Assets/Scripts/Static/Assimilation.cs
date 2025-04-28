using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class Assimilation
{
    [System.Serializable]
    public class ShipData
    {
        public GameObject shipType;
        public Vector2 hubLocation;
        public Vector2 gameLocation;
        public Quaternion minionAngle;
        public Sprite stickerSprite;
    }

    public static List<ShipData> collectionList = new List<ShipData>();
    public static List<ShipData> minionList = new List<ShipData>();

    public static void swapToMinionList(ShipData shipData)
    {
        minionList.Add(shipData);
        collectionList.Remove(shipData);
    }
    public static void swapToCollectionList(ShipData shipData)
    {
        collectionList.Add(shipData);
        minionList.Remove(shipData);
    }
}
