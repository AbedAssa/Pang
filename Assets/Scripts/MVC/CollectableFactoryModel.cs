using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// FactoryModel holding all data needed for collectable object like extra coins gift, weapons and helps,etc.
public class CollectableFactoryModel : PangElement
{

    //Refrence to bounce score.
    [SerializeField]
    private GameObject extraCoinsGiftPrefab;
    //Number of the gift can be displayed in the game.
    [SerializeField]
    private int numberOfExtraCoinsInGame;
    //Time need to wait to init bounce prefab.
    [SerializeField]
    private float timeSpereatingEachCoinsGift;
    
    public float GetRepeatedTimeBounce()
    {
        return timeSpereatingEachCoinsGift;
    }

    public GameObject GetExtraCoinsPrefab()
    {
        return extraCoinsGiftPrefab;
    }

    public float GetTimeSeperateExtraCoins()
    {
        return this.timeSpereatingEachCoinsGift;
    }

    public int GetNumberOfExtraCoins()
    {
        return numberOfExtraCoinsInGame;
    }
}
