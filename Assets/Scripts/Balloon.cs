using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represent a balloon object.
public class Balloon : PangElement
{
    //Refrence to ballon size.
    public int balloonSize = 3;

    //Add random force to the balloon when initialized so it moves randomly.
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-10,10),10, 0),ForceMode2D.Impulse);
    }

    //whenever the balloon collided with a pullet it gets destroyed and notifies all controllers.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pullet"))
        {
            app.Notify(PangNotification.BalloonExplosion,this);
            AudioManager.instance.PlaySound(EAudioType.BalloonExplosion);
            Destroy(gameObject);
        }
    }
}
