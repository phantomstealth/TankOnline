using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    private Rigidbody TankEngine;
    public GameObject bullit;
    public Transform StartPosition;
    public float RotateSpeed = 20f;
    public float RotateSpeedTower = 2f;
    public float SpeedRaiseWeapon = 0.5f;
    public float MoveSpeed = 1.5f;
    public float CurrentSpeed = 0;
    int SpeedNum = 0;
    public GameObject pivot;
    public GameObject baseweapon;
    public GameObject corpse;
    public int weaponRotY=35;
    public int weaponRotX=0;
    public GameObject fullTank;

    // Start is called before the first frame update
    void Start()
    {
        TankEngine = fullTank.GetComponent<Rigidbody>();
        //Debug.Log(pivot.transform.rotation.x.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag!="bullet")
            SpeedNum = 0;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Transmission();
        Move();
        Rotates();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShotRocket();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (weaponRotY > 0)
            {
                pivot.transform.Rotate(new Vector3(SpeedRaiseWeapon, 0f, 0f));
                weaponRotY--;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (weaponRotY < 83)
            {
                pivot.transform.Rotate(new Vector3(-SpeedRaiseWeapon, 0f, 0f));
                weaponRotY++;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            baseweapon.transform.Rotate(new Vector3(0f, -RotateSpeedTower, 0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            baseweapon.transform.Rotate(new Vector3(0f, RotateSpeedTower, 0f));
        }

        float Axis = Input.GetAxis("Vertical");
        if (Input.GetButtonUp("Vertical"))
        {
            if (Axis > 0) UpSpeed();
            if (Axis < 0) DownSpeed();
        }
    }

    void UpSpeed()
    {
        if ((SpeedNum + 1) < 6) SpeedNum++;
    }

    void DownSpeed()
    {
        if ((SpeedNum - 1) > -2) SpeedNum--;
    }

    void Transmission()
    {
        switch (SpeedNum)
        {
            case -1: CurrentSpeed = -1;  RotateSpeed = 25;break;
            case 0: CurrentSpeed = 0;    RotateSpeed = 20; break;
            case 1: CurrentSpeed = 0.5f; RotateSpeed = 25; break;
            case 2: CurrentSpeed = 1f;   RotateSpeed = 30; break;
            case 3: CurrentSpeed = 1.5f; RotateSpeed = 35; break;
            case 4: CurrentSpeed = 2f;   RotateSpeed = 40; break;
            case 5: CurrentSpeed = 2.5f; RotateSpeed = 45; break;
        }
    }
    void ShotRocket()
    {
        GameObject NewBullit = Instantiate(bullit, StartPosition.transform.position, StartPosition.transform.rotation);
    }
    void Move()
    {
        //_rigidbodyFullTank.AddRelativeForce(Vector3.forward * speedTank, ForceMode.Impulse);
        Vector3 Move = transform.forward * CurrentSpeed * MoveSpeed * Time.deltaTime;
        Vector3 Poze = TankEngine.position + Move;
        TankEngine.MovePosition(Poze);
    }

    void Rotates()
    {
        float R = Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime;
        Quaternion RotateAngle = Quaternion.Euler(0, R, 0);
        Quaternion CurrentUgol = TankEngine.rotation*RotateAngle;
        TankEngine.MoveRotation(CurrentUgol);
    }
}
