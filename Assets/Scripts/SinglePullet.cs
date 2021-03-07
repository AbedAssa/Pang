using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represent single pullet.
public class SinglePullet : PangElement
{
    //Speed of pullet.
    public float speed = 10;

    //Play pullet sound when pullet is initilaized.
    private void Start()
    {
        AudioManager.instance.PlaySound(EAudioType.Shoot);
    }

    //Move pullet position top.
    void Update() 
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    //Destroy pullet when it collid with other object.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    //Draw raycast from pullet position to the ground, and destroy all balloons under the pullet.
    //notify controller about the balloon which destroyed.
    private void FixedUpdate()
    {
        RaycastHit2D[]  hit = Physics2D.RaycastAll(transform.position, -Vector2.up);
        if(hit != null)
        {
            foreach(RaycastHit2D raycastHit in hit)
            {
                if (raycastHit.collider.CompareTag("Balloon"))
                {
                    app.Notify(PangNotification.BalloonExplosion, raycastHit.collider.gameObject.GetComponent<Balloon>());
                    AudioManager.instance.PlaySound(EAudioType.BalloonExplosion);
                    Destroy(raycastHit.collider.gameObject);
                }
            }
        }
    }
}
