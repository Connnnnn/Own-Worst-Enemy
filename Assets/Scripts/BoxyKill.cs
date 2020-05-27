using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyKill : MonoBehaviour
{
    //public Rigidbody2D rgbd;
    public CharacterController2D character;

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            if (rgbd.velocity.y <= -5f) {
                character.Damage(10);
                Debug.Log("Hit player 2");
            }
        }
    }
*/
    public Rigidbody2D _body;
    private float minimumDamageThreshold=10;
    private float collisionDamageScale=.2f;


    void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 normal = collision.GetContact(0).normal;
        Vector2 impulse = ComputeTotalImpulse(collision);

        Vector2 myIncidentVelocity = _body.velocity - (impulse / _body.mass);

        Vector2 otherIncidentVelocity = Vector2.zero;
        var otherBody = collision.rigidbody;
        if (otherBody != null)
        {
            otherIncidentVelocity = otherBody.velocity;
            if (!otherBody.isKinematic)
                otherIncidentVelocity += impulse / otherBody.mass;
        }

        // Compute how fast each one was moving along the collision normal,
        // Or zero if we were moving against the normal.
        float myApproach = Mathf.Max(0f, Vector3.Dot(myIncidentVelocity, normal));
        float otherApproach = Mathf.Max(0f, Vector3.Dot(otherIncidentVelocity, normal));

        float damage = Mathf.Max(0f, otherApproach - myApproach - minimumDamageThreshold);
        Debug.Log(damage);
        character.Damage(damage * collisionDamageScale);
    }
    static Vector2 ComputeTotalImpulse(Collision2D collision)
    {
        Vector2 impulse = Vector2.zero;

        int contactCount = collision.contactCount;
        for (int i = 0; i < contactCount; i++)
        {
            var contact = collision.GetContact(0);
            impulse += contact.normal * contact.normalImpulse;
            impulse.x += contact.tangentImpulse * contact.normal.y;
            impulse.y -= contact.tangentImpulse * contact.normal.x;
        }

        return impulse;
    }
}
