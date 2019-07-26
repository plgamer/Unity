using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>
    ///3秒后回收到对象池
    /// </summary>
    /// <returns></returns>
    IEnumerator AutoRecyle()
    {
        yield return new WaitForSeconds(1f);
        ObjectPool.GetInstance().Recycleobj(gameObject);
    }
    private void OnEnable()
    {
        StartCoroutine(AutoRecyle());
    }
}
