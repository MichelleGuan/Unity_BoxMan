using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Collections;

public class Walk : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
   GameObject[] box;
   public static float speed= 0.4F;
   public static bool activeyouw = false;
   Vector2 lef = Vector2.left;
   Vector2 rig = Vector2.right;
   Vector2 up = Vector2.up;
   Vector2 dow = Vector2.down;
   List<int> list = new List<int>();
   GameObject panelend;
   private Transform leftCheck;
   private Transform rightCheck;
   private Transform topCheck;
   private Transform bottomCheck;
   bool left;
   bool right;
   bool top;
   bool bottom;
   Button buttonA;
   public void Start()
   {
       Transform window= GameObject.Find("Canvas").transform;
       this.transform.SetParent(window,false);
       //获取所有需要的对象
       box = GameObject.FindGameObjectsWithTag("box");
       panelend = GameObject.Find("PanelEnd");
       leftCheck = transform.Find("LeftCheck");
       rightCheck = transform.Find("RightCheck");
       topCheck = transform.Find("TopCheck");
       bottomCheck = transform.Find("BottomCheck");
       buttonA = GameObject.Find("A Button").GetComponent<Button>();
   }

   public void Update()
   {
       //按键一直走
       if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
       {
           WalkUp();
           JudgeWin();
           BoxMove.Top = false;
       }
       if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
       {
           WalkDown();
           JudgeWin();
           BoxMove.Bottom = false;
       }
       if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
       {
           WalkLeft();
           JudgeWin();
           BoxMove.Left = false;
       }
       if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
       {
           WalkRight();
           JudgeWin();
           BoxMove.Right = false;
       }
   }

    //判断胜负，当四个箱子都到达终点区域时跳出youwin窗口
   public void JudgeWin()
   {
       foreach (GameObject d in box)
       {
           if (d != null) {
           if (d.transform.position.x > panelend.transform.position.x - 5 && panelend.transform.position.y + 5 > d.transform.position.y && panelend.transform.position.y - 3 < d.transform.position.y && d.transform.position.x < panelend.transform.position.x + 3)
           {
               list.Add(1);
           }
       }
       }
       if (list.Count == 4)
       {
            if (GameObject.Find("YouWin") == null) { 
            var youwin = (Instantiate(Resources.Load("YouWin")) as GameObject).transform;
             youwin.gameObject.name = "YouWin";
             youwin.SetParent(GameObject.Find("ControlPanel").transform);
             youwin.localScale = new Vector3(1, 1, 1);
             youwin.localPosition = new Vector3(0, 0, 0);
             Invoke("DestoryYouwin", 3f);
           }
       }
       list = new List<int>();
   }
   public void DestoryYouwin()
   {
       Destroy(GameObject.Find("YouWin"));
   }

   //向左走事件，通过屏幕按键A，键盘A左触发
   public void WalkLeft()
   { 
         //用射线判断机器人左侧是不是有墙
       left = Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Wall"));     
         //如果机器人左边没有墙且推的箱子的左边没有墙，机器人向左走
       if (!left && !BoxMove.Left)
       {
           player.transform.Translate(lef*speed);
       }
    
    }  
    public void WalkRight()
    {
        right = Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Wall"));
        if(!right && !BoxMove.Right)
        { 
                player.transform.Translate(rig*speed);   
        }   
     }
    public void WalkUp()
    {
        top = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Wall"));
        if(!top && !BoxMove.Top)
        { 
                player.transform.Translate(up*speed);
        }
     }
    public void WalkDown()
    {
        bottom = Physics2D.Linecast(transform.position, bottomCheck.position, 1 << LayerMask.NameToLayer("Wall"));
        if(!bottom && !BoxMove.Bottom)
        { 
            player.transform.Translate(dow*speed); 
        }
    }
}
