using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform muzzleTransform;
    public Transform gunTransform;
    public Camera cam;
    private Vector3 mousePos;
    private Vector2 gunDirection;

    public bool isEquipped;
    public Transform WeaponHolderTransform;
    public GameObject GunName;

    // Start is called before the first frame update
    void Start()
    {
        isEquipped = false;
        WeaponHolderTransform = GameObject.Find("WeaponHolder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WeaponHolderTransform.position==gunTransform.position)
        {
            isEquipped = true;
            string gunName = GunName.name;
            if(isEquipped)
            {
                //detect the coordinates of where player clicks
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                //get the direction of the vector
                gunDirection = (mousePos - transform.position).normalized;
                //calculate the angle of rotation
                float angle = Mathf.Atan2(gunDirection.y,gunDirection.x)*Mathf.Rad2Deg;
                //make object rotate according to the angle
                transform.eulerAngles = new Vector3(0,0,angle);

                if(Mathf.Abs(angle) > 90 && transform.localScale.y > 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y,transform.localScale.z);
                }
                else if(Mathf.Abs(angle) < 90 && transform.localScale.y < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y,transform.localScale.z);
                }

                //if user clicks mouse
                if(Input.GetMouseButtonDown(0) && gunName == "WheelGun")
                {
                    //generate a bullet and rotate the same angle as the muzzle
                    Instantiate(bullet, muzzleTransform.position,Quaternion.Euler(transform.eulerAngles));
                }
                else if(Input.GetMouseButton(0) && gunName == "GatlinGun")
                {
                    //generate a bullet and rotate the same angle as the muzzle
                    Instantiate(bullet, muzzleTransform.position,Quaternion.Euler(transform.eulerAngles));
                }
            }
        }
    }

}
