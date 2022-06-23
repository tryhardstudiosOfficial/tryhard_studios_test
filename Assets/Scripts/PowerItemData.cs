using UnityEngine;

[CreateAssetMenu(fileName = "PowerItemData", menuName = "ScriptableObjects/PowerItemData", order = 1)]
public class PowerItemData : ScriptableObject {

    public string PowerItemName;
    public string PowerItemDescription;
    public float PowerItemDuration;
}