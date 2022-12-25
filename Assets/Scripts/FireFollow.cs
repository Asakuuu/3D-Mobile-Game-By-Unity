using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollow : MonoBehaviour
{
    public GameObject target; // 追蹤的目標（在Unity中拖曳指定）
    private Vector3 offset; // 與目標的座標差異

    void Start()
    {
        // 遊戲開始時，先計算自己與目標的座標差異，並儲存起來
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        // 遊戲執行時，一直將自己座標設為：目標座標 + 差異數
        transform.position = target.transform.position + offset;
    }
}