using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFObullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Destroy", 4f);
    }
    void Start()
    {
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
