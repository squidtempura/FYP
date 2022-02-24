using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform muzzleTransform;
    public Camera cam;
    private Vector3 mousePos;
    private Vector2 gunDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //detect the coordinates of where player clicks
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //get the direction of the vector
        gunDirection = (mousePos - transform.position).normalized;
        //calculate the angle of rotation
        float angle = Mathf.Atan2(gunDirection.y,gunDirection.x)*Mathf.Rad2Deg;
        //make object rotate according to the angle
        transform.eulerAngles = new Vector3(0,0,angle);

        //if user clicks mouse
        if(Input.GetMouseButtonDown(0))
        {
            //generate a bullet and rotate the same angle as the muzzle
            Instantiate(bullet, muzzleTransform.position,Quaternion.Euler(transform.eulerAngles));
        }
    }

}
