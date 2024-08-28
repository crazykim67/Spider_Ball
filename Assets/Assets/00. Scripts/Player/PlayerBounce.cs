using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    private Rigidbody2D rg;
    [SerializeField]
    private HookController hookController;

    Vector2 velocity;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        hookController = GetComponent<HookController>();
    }

    private void Update()
    {
        velocity = rg.velocity;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Monster"))
        {
            //�浹 �� �׷����� Ǯ���鼭 �ݴ� �������� ƨ�ܳ���
            if(hookController.isAttach)
                hookController.UnGrappling();

            float speed = velocity.magnitude;
            Vector2 dir = Vector2.Reflect(velocity.normalized, coll.contacts[0].normal);

            rg.velocity = dir * Mathf.Max(speed, 0f);
        }
        else if (coll.transform.CompareTag("NoRing"))
            if (hookController.isAttach) 
                hookController.UnGrappling();
    }
}
