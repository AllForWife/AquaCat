using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Allfun : MonoBehaviour
{

    public static float setHpUi(Transform hpCanvas, float hp, float hp_max)
    {
        var hpUi = hpCanvas.GetChild(0).GetChild(0);
        hpUi.GetComponent<Image>().fillAmount = hp / hp_max;
        return hp;
    }

}
public class GameControl : MonoBehaviour
{

    public List<GameObject> BulletList = new List<GameObject>();
    public static GameControl inst;
    public enum bullet
    {
        ball,//0
        slash//1
    }
    // Start is called before the first frame update
    void Awake()
    {
        inst = this;
    }

    // 列舉遊戲狀態
    // Update is called once per frame
    void Update()
    {
        
    }
}
