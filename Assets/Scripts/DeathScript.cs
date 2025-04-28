using UnityEngine;

public class DeathScript : MonoBehaviour
{

    public GameObject minionType;
    public GameObject pickUp;

    public void spawnPickUp()
    {
        GameObject newPickUp = Instantiate(pickUp);
        newPickUp.GetComponent<ShipPickUp>().shiptype = minionType;
    }

}
