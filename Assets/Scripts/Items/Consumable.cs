using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]

public class Consumable : Item
{
    public ConsumableType type;
}

public enum ConsumableType { Medkit }