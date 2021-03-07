using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represent a extra coin object.
public class ExtraCoin : MonoBehaviour
{
    ///This function notifies controllers when the player or pullet hits the gift, and plays sound.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent != null)
        {
            transform.parent.GetComponent<CollectableFactoryView>().app.Notify(PangNotification.CollectedExtraCoinGift, this);
        }
        AudioManager.instance.PlaySound(EAudioType.Coin);
        Destroy(this.gameObject);
    }

}
