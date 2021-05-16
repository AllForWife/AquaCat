using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform hpCanvas;
    public float hp;
    float hp_max;
    public GameObject DieEffect;
    public GameObject HitEffect;
    // Start is called before the first frame update
    void Start()
    {
        hp_max = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("bullet"))
        {
            hp = Allfun.setHpUi(hpCanvas, hp - col.GetComponent<bullet>().atk, hp_max);
            Instantiate(HitEffect, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            if (hp <= 0)
            {
                Instantiate(DieEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
