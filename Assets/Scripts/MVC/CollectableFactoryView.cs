using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// CollectableFactoryView to display collectable objects in scene.
public class CollectableFactoryView : PangElement
{
    /// This function instantiate collectable object in a random position.
    /// parammeters:
    ///     prefab: the collectable object to instantiate.
    public void InitPrefab(GameObject prefab)
    {
        float randomPositionX = Random.Range(Screen.width * 0.1f, Screen.width * 0.9f);
        Vector2 position = Camera.main.ScreenToWorldPoint(new Vector2(randomPositionX, Screen.height));
        Instantiate(prefab, position,this.transform.rotation,this.transform);
    }
}
