using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUfoBulletMode2 : MonoBehaviour
{
    private float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireMode2", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir =(bulMoveVector - transform.position).normalized;

        GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<UFObullet>().SetMoveDirection(bulDir);
            angle += 10f;
    }
}
