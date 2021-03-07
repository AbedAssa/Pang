using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// FactoryController for creating all collectable objects.
public class CollectableFactoryController : PangElement
{

    private void Start()
    {
        StartCoroutine("InitExtraCoinsGift");
    }

    /// This function initilaize new collectable gift coins.
    private IEnumerator InitExtraCoinsGift()
    {
        for (int i = 0; i < app.model.CollectableFactoryModel.GetNumberOfExtraCoins(); i++)
        {
            app.view.factoryView.InitPrefab(app.model.CollectableFactoryModel.GetExtraCoinsPrefab());
            yield return new WaitForSeconds(app.model.CollectableFactoryModel.GetTimeSeperateExtraCoins());
        }
    }
}
