using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    #region
    private static ObjectPool instance;
    private ObjectPool()
    {
        pool = new Dictionary<string, List<GameObject>>();
        prefabs = new Dictionary<string, GameObject>();
    }
    public static ObjectPool GetInstance()
    {
        if(instance==null)
        {
            instance = new ObjectPool();
        }
        return instance;
    }
    #endregion

    ///<summary>
    ///对象池
    /// </summary>
    private Dictionary<string, List<GameObject>> pool;

    ///<summary>
    ///预设体
    /// </summary>
    private Dictionary<string, GameObject> prefabs;

    ///<summary>
    ///从对象池获取对象
    /// </summary>
    /// <param name="objName"><</param>
    /// <returns></returns>
    public GameObject GetObj(string objName)
    {
        GameObject result = null;
        if (pool.ContainsKey(objName))
        {
            //对象池里有该对象
            if (pool[objName].Count > 0)
            {
                //获取结果
                result = pool[objName][0];
                //激活对象
                result.SetActive(true);
                //从池中移除该对象
                pool[objName].Remove(result);
                return result;
            }
        }
        //对象池没有该对象
        GameObject prefab = null;
        if (prefabs.ContainsKey(objName))//预设体池里有该对象
        {
            prefab = prefabs[objName];
        }
        else //预设体池里还没有加载该预设体
        {
            //加载预设体
            prefab = Resources.Load<GameObject>("Prefabs/" + objName);
            //refresh Dictionary
            prefabs.Add(objName, prefab);
        }
        //生成
        result = Object.Instantiate(prefab);
        //改名(去除 clone）
        result.name = objName;
        return result;
    }

    ///<summary>
    ///回收对象到对象池
    /// </summary>
    /// <param name="objName"></param>
    public void Recycleobj(GameObject obj)
    {
        //设置为非激活
        obj.SetActive(false);
        //判断该对象是否属于某个对象池
        if(pool.ContainsKey(obj.name))
        {
            //放置进该类资源的对象池
            pool[obj.name].Add(obj);
        }
        else
        {
            //没有现有池，创建该类型的池，并将对象放入
            pool.Add(obj.name, new List<GameObject>() { obj });
        }
    }

}

