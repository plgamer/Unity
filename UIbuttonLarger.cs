using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIbuttonLarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    void Start()
    {
        gameObject.GetComponent<Animator>().enabled=false;
    }
    public void OnPointerEnter(PointerEventData eventData)//鼠标进入按钮触发音效和动画
    {

        gameObject.GetComponent<Animator>().enabled = true;
     
            
    
    }
    //鼠标离开时关闭动画
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
       }

    
}

