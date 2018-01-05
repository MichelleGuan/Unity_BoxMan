using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmove : MonoBehaviour {
    public static bool Left=false;
    public static bool Right=false;
    public static bool Top=false;
    public static bool Bottom=false;
    bool left;
    bool right;
    bool top;
    bool bottom;
    bool leftRobot;
    bool rightRobot;
    bool topRobot;
    bool bottomRobot;
    public static bool leftBox;
    public static bool rightBox;
    public static bool topBox;
    public static bool bottomBox;
    private Transform leftCheck;
    private Transform rightCheck;
    private Transform topCheck;
    private Transform bottomCheck;
	void Start () {
        leftCheck = transform.Find("LeftCheck");
        rightCheck = transform.Find("RightCheck");
        topCheck = transform.Find("TopCheck");
        bottomCheck = transform.Find("BottomCheck");
	}
	void Update () {
        Push();
	}
    public void Push()
    {
        //判断各个方向是否有机器人和墙
      rightRobot = Physics2D.Linecast(transform.position, rightCheck.position,1 << LayerMask.NameToLayer("Robot"));
      left = Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Wall"));
      right = Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Wall"));
      top = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Wall"));
      bottom = Physics2D.Linecast(transform.position, bottomCheck.position, 1 << LayerMask.NameToLayer("Wall"));
      leftRobot = Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Robot"));
      topRobot = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("Robot"));
      bottomRobot = Physics2D.Linecast(transform.position, bottomCheck.position, 1 << LayerMask.NameToLayer("Robot"));
      leftBox = Physics2D.Linecast(leftCheck.position, leftCheck.position, 1 << LayerMask.NameToLayer("box"));
      rightBox = Physics2D.Linecast(rightCheck.position, rightCheck.position, 1 << LayerMask.NameToLayer("box"));
      topBox = Physics2D.Linecast(topCheck.position, topCheck.position, 1 << LayerMask.NameToLayer("box"));
      bottomBox = Physics2D.Linecast(bottomCheck.position, bottomCheck.position, 1 << LayerMask.NameToLayer("box"));
        //机器人在正右边而且左边没有墙没有箱子,箱子就向左走
      if (rightRobot && !left && !leftBox)
     {
         gameObject.transform.Translate(Vector2.left*Walk.speed);
     }
        //机器人在右边且左边有墙或者箱子,让机器人停下来
     if(rightRobot && (left||leftBox))
     {
         Left = true;
     }
     if(leftRobot && !right && !rightBox)
     {
         gameObject.transform.Translate(Vector2.right * Walk.speed);
     }
     if(leftRobot && (right||rightBox))
     {
         Right = true;
     }
     if(topRobot && !bottom && !bottomBox)
     {
         gameObject.transform.Translate(Vector2.down * Walk.speed);
     }
     if(topRobot && (bottom||bottomBox))
     {
         Top = true;
     }
     if(bottomRobot && !top &&!topBox)
     {
         gameObject.transform.Translate(Vector2.up * Walk.speed);
     }
     if(bottomRobot &&(top||topBox))
     {
         Bottom = true;
     }
    }

}
