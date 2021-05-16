using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Biological
{

    public float speed;
    float fire_Time;
    public float fire_Time_Max = 0.3f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    void RotateMouse(float speed)
    {
        // 獲取目標物件當前的世界座標系位置，並將其轉換為螢幕座標系的點
        Vector3 Pos = Camera.main.WorldToScreenPoint(transform.position);
        // 設定滑鼠的螢幕座標向量，用上面獲得的Pos的z軸資料作為滑鼠的z軸資料，使滑鼠座標與目標物件座標處於同一層面上
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Pos.z);
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
        transform.up = Vector3.Lerp(transform.up, (target - transform.position), speed * Time.deltaTime);
    }
    void Move()
    {
        float hor = Input.GetAxis("Horizontal") * speed;//A  D
        float ver = Input.GetAxis("Vertical") * speed;//W S
        rig.velocity = new Vector2(hor, ver);
    }
    void Fire()
    {
        var control = GameControl.inst;
        fire_Time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(fire_Time >= fire_Time_Max)
            {
                Instantiate(control.BulletList[(int)GameControl.bullet.ball], transform.position, transform.rotation);
                fire_Time = 0;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Fire();
        RotateMouse(5);
    }
}
