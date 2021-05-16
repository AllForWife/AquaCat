using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Biological : MonoBehaviour
{
    public Rigidbody2D rig;
    Animator ani;

    Tween shake_Do;//用來存取晃動的動畫
    Tween color_Do;//用來存取變色的動畫
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    public void Shake()
    {
        if (shake_Do == null)//當晃動動畫不存在時
        {
            shake_Do = transform.DOShakePosition(0.5f, 0.2f);
            //賦址給一個新的晃動動畫
            //第一個參數為晃動大小 第二個參數為執行秒數
            //此方法為用來晃動位置
            transform.DOShakeScale(0.5f, 0.2f);
            //同理 晃動大小
            color_Do = transform.GetComponent<SpriteRenderer>().DOColor(new Color32(255, 200, 200, 255), 0.075f);
            //獲取圖片元件做顏色漸變
            //將顏色設置為紅色
            //此RGBA顏色參數請自行去查顏色表
        }
        else
        {
            if (!shake_Do.IsPlaying())
            {
                //當動畫沒被執行的話 做跟上面同樣的效果 
                //這樣寫的理由 是因為如果shake_Do為空的話
                //直接使用方法會報錯 或許也可改寫成try catch
                shake_Do = transform.DOShakePosition(0.2f, 0.2f);
                transform.DOShakeScale(0.2f, 0.2f);
                color_Do = transform.GetComponent<SpriteRenderer>().DOColor(new Color32(255, 200, 200, 255), 0.075f);
            }
        }
    }//將此動畫放置在碰撞處理中 即可做出受擊效果
    public void Re_Do()
    {
        if (color_Do != null)
        {
            if (!color_Do.IsPlaying())
            {
                color_Do = transform.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.1f);
            }
        }//將此放置在Update裡面 將顏色漸變動畫結束後可以還原原本顏色
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
