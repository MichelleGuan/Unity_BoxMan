using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
   GameObject walldown;
   GameObject wallup;
   GameObject wallleft;
   GameObject wallright;
   GameObject walllie;
   GameObject wallstand;
   GameObject walllieend;
   GameObject wallstandend;
   GameObject[] box;
   public float speed;
   Vector2 lef = Vector2.left;
   Vector2 rig = Vector2.right;
   Vector2 up = Vector2.up;
   Vector2 dow = Vector2.down;
   public GameObject target;
   List<int> list = new List<int>();
   GameObject panelend;
    //判断胜负
   public void JudgeWin()
   {
       foreach (GameObject d in box)
       {
           if (d.transform.position.x > panelend.transform.position.x - 5 && panelend.transform.position.y + 5 > d.transform.position.y && panelend.transform.position.y - 3 < d.transform.position.y && d.transform.position.x < panelend.transform.position.x + 3)
           {
               list.Add(1);
           }
       }
       if (list.Count == 4)
       {
           target.transform.localScale = new Vector3(1, 1, 1);
       }
       list = new List<int>();
   }
    //向左走事件，通过屏幕按键A，键盘A左触发
   public void WalkLeft()
   {
       //每步一判定，按键走3步
           //机器人撞到竖着的墙就不走
           if (player.transform.position.x > wallstand.transform.position.x - 1 && player.transform.position.y < wallstandend.transform.position.y + 4 && player.transform.position.x < wallstand.transform.position.x + 2) { }
           //机器人撞到躺着的墙就不走
           else if (player.transform.position.x < walllieend.transform.position.x + 6 && player.transform.position.y > walllie.transform.position.y - 1 && player.transform.position.y < walllie.transform.position.y + 4.5) { }
           //不撞到左边的墙
           else if (player.transform.position.x > wallleft.transform.position.x + 2)
           {
               //遍历四个箱子
               foreach (GameObject d in box)
               {
                   //如果机器人在箱子正右边
                   if (player.transform.position.x > d.transform.position.x + 1 && d.transform.position.y + 3 > player.transform.position.y && d.transform.position.y - 3 < player.transform.position.y && player.transform.position.x < d.transform.position.x + 4)
                   {
                       //如果箱子撞到任意墙，箱子不走，机器人也不走
                       if (d.transform.position.x > wallstand.transform.position.x - 1 && d.transform.position.y < wallstandend.transform.position.y + 4 && d.transform.position.x < wallstand.transform.position.x + 3) { lef = Vector2.zero; }
                       else if (d.transform.position.x < walllieend.transform.position.x + 6 && d.transform.position.y > walllie.transform.position.y - 1 && d.transform.position.y < walllie.transform.position.y + 4.5) { lef = Vector2.zero; }
                       else if (d.transform.position.x <= wallleft.transform.position.x + 2.5) { lef = Vector2.zero; }
                       //箱子撞到箱子，箱子不走，机器人也不走
                       foreach (GameObject e in box)
                       {
                           if (d.transform.position.x > e.transform.position.x + 1 && e.transform.position.y + 3 > d.transform.position.y && e.transform.position.y - 3 < d.transform.position.y && d.transform.position.x < e.transform.position.x + 4)
                           { lef = Vector2.zero; }
                       }
                       //什么都没撞到，箱子正常走
                       d.transform.Translate(lef*speed);  
                   }
               }
               //机器人向左走
               player.transform.Translate(lef*speed);
           }
           //初始化Vector2的值
           lef = Vector2.left;
       }  

    //向右走事件，通过屏幕按键D，键盘D右触发
    public void WalkRight()
    {
            //机器人撞到竖着的墙就不走
            if (player.transform.position.x < wallstand.transform.position.x + 1 && player.transform.position.y < wallstandend.transform.position.y + 5 && player.transform.position.x > wallstand.transform.position.x - 5) { }
                //机器人不撞到右边的墙
            else if (player.transform.position.x < wallright.transform.position.x - 6)
            {

                //遍历四个箱子
                foreach (GameObject d in box)
                {
                    //如果机器人在箱子正左边
                    if (player.transform.position.x < d.transform.position.x - 1 && d.transform.position.y + 3> player.transform.position.y && d.transform.position.y - 3 < player.transform.position.y && player.transform.position.x > d.transform.position.x - 4)
                    {
                        //如果箱子撞到任意墙，箱子不走，机器人也不走
                        if (d.transform.position.x < wallstand.transform.position.x + 1 && d.transform.position.y < wallstandend.transform.position.y + 5 && d.transform.position.x > d.transform.position.x - 6) { rig = Vector2.zero; }
                        else if (d.transform.position.x >= wallright.transform.position.x - 6) { rig = Vector2.zero; }
                        //箱子撞到箱子，箱子不走，机器人也不走
                       foreach (GameObject e in box)
                       {
                            if (d.transform.position.x < e.transform.position.x -1 && e.transform.position.y + 3 > d.transform.position.y && e.transform.position.y - 3 < d.transform.position.y && d.transform.position.x > e.transform.position.x -4)
                            { rig = Vector2.zero; }
                       }

                        //什么都没撞到，箱子正常走
                        d.transform.Translate(rig*speed);
                    }
                }  
                //机器人向右走
                player.transform.Translate(rig*speed);
            }
            //初始化Vector2的值
            rig = Vector2.right;
        }

    //向上走事件，通过屏幕按键W，键盘W上触发
    public void WalkUp()
    { 
            //机器人撞到躺着的墙就不走
            if (player.transform.position.x < walllieend.transform.position.x + 5 && player.transform.position.y < walllie.transform.position.y + 2 && player.transform.position.y > walllie.transform.position.y-2) { }
                //机器人不撞到上面的墙
            else if (player.transform.position.y < wallup.transform.position.y - 3)
            {

                //遍历四个箱子
                foreach (GameObject d in box)
                {
                    //如果机器人在箱子正下方
                    if (player.transform.position.y < d.transform.position.y - 1 && d.transform.position.x+ 2> player.transform.position.x && d.transform.position.x - 2 < player.transform.position.x && player.transform.position.y > d.transform.position.y- 4)
                    {
                        //如果箱子撞到任意墙，箱子不走，机器人也不走
                        if (d.transform.position.x < walllieend.transform.position.x + 5 && d.transform.position.y < walllie.transform.position.y + 2 && d.transform.position.y > walllie.transform.position.y - 3) { up = Vector2.zero; }
                        else if (d.transform.position.y >= wallup.transform.position.y - 2) { up = Vector2.zero; }
                        //箱子撞到箱子，箱子不走，机器人也不走
                        foreach (GameObject e in box)
                        {
                            if (d.transform.position.y < e.transform.position.y - 1 && e.transform.position.x + 2 > d.transform.position.x && e.transform.position.x - 2 < d.transform.position.x && d.transform.position.y > e.transform.position.y - 4)
                            { up = Vector2.zero; }
                        }
                        //什么都没撞到，箱子正常走
                        d.transform.Translate(up*speed);
                    }                  
                }  
                //机器人向上走
                player.transform.Translate(up*speed);
            }
            //初始化Vector2的值
            up = Vector2.up;
    }

    //向下走事件，通过屏幕按键S，键盘S下触发
    public void WalkDown()
    {
        //机器人撞到躺着的墙就不走
        if (player.transform.position.x < walllieend.transform.position.x + 5 && player.transform.position.y < walllie.transform.position.y + 6 && player.transform.position.y > walllie.transform.position.y) { }
        //机器人撞到站在的墙就不走
        else if (player.transform.position.y < wallstandend.transform.position.y + 6 && player.transform.position.x > wallstand.transform.position.x - 5 && player.transform.position.x < wallstand.transform.position.x + 1) { }
        //机器人不撞到下面的墙
        else if (player.transform.position.y > walldown.transform.position.y + 7)
        {
            //遍历四个箱子
            foreach (GameObject d in box)
            {
                //如果机器人在箱子正上边
                if (player.transform.position.y < d.transform.position.y + 4 && d.transform.position.x + 2 > player.transform.position.x && d.transform.position.x - 2 < player.transform.position.x && player.transform.position.y > d.transform.position.y + 1)
                {
                    //如果箱子撞到任意墙，箱子不走，机器人也不走
                    if (d.transform.position.x < walllieend.transform.position.x + 5 && d.transform.position.y < walllie.transform.position.y + 6 && d.transform.position.y > walllie.transform.position.y) { dow = Vector2.zero; }
                    else if (d.transform.position.y < wallstandend.transform.position.y + 6 && d.transform.position.x > wallstand.transform.position.x - 5 && d.transform.position.x < wallstand.transform.position.x + 1) { dow = Vector2.zero; }
                    else if (d.transform.position.y <= walldown.transform.position.y + 6) { dow = Vector2.zero; }
                    //箱子撞到箱子，箱子不走，机器人也不走
                    foreach (GameObject e in box)
                    {
                        if (d.transform.position.x > e.transform.position.x + 1 && e.transform.position.y + 3 > d.transform.position.y && e.transform.position.y - 3 < d.transform.position.y && d.transform.position.x < e.transform.position.x + 4)
                        { dow = Vector2.zero; }
                    }
                    //什么都没撞到，箱子正常走
                    d.transform.Translate(dow*speed);
                }
            }
            //机器人向下走
            player.transform.Translate(dow*speed);
        }
        //初始化Vector2的值
        dow = Vector2.down;
    }
	// Update is called once per frame
    public void Start()
    {
        //获取所有需要的对象
        wallleft = GameObject.Find("Wall 1 (24)");
        wallright = GameObject.Find("Wall 1 (25)");
        wallup = GameObject.Find("Wall 1 (23)");
        walldown = GameObject.Find("Wall 1 (22)");
        wallstand = GameObject.Find("Wall 1 (26)");
        walllie = GameObject.Find("Wall 1 (27)");
        wallstandend = GameObject.Find("wallstandend");
        walllieend = GameObject.Find("Walllieend");
        box = GameObject.FindGameObjectsWithTag("box");
        panelend = GameObject.Find("PanelEnd");
    }
	public void Update () {
       //按键走3步
        if (Input.GetKey(KeyCode.W)||Input.GetKey( KeyCode.UpArrow))
        {           
            WalkUp();
            JudgeWin();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            WalkDown();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            WalkLeft();
            JudgeWin();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            WalkRight();
        }
	}
}
