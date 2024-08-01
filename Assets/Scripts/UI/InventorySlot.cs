using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfor;


    public WeaponInfo GetWeaponInfo()
    {

        return weaponInfor;
    }
}
