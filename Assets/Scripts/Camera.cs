using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //inspectorで設定可能なprivate変数
    //参照の設定
    [SerializeField]
    private Transform pivot = null;

    void Start()
    {
        if (pivot == null) pivot = transform.parent;
    }

    //x軸の回転(縦)には制限をつける出ないと地球が回転したように移動する。
    [Range(-0.999f, -0.5f)]
    public float minYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float maxYAngle = 0.5f;

    void Update()
    {
        //マウス入力。x_roteはlocalでいうy,y_roteはlocalでいうx
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        //xはそのまま回転
        pivot.transform.Rotate(0, X_Rotation, 0);

        //yは制限を超えない範囲で回転
        float nowAngle = pivot.transform.localRotation.x;
        if(-Y_Rotation != 0)
        {
            if (0 < Y_Rotation)
            {
                if(minYAngle <= nowAngle)
                {
                    pivot.transform.Rotate(Y_Rotation, 0, 0);
                }
            }
            else
            {
                if(nowAngle <= maxYAngle)
                {
                    pivot.transform.Rotate(Y_Rotation, 0, 0);
                }
            }
        }
        //z角がずれてくるのでzのみ0で初期化
        pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, 0f);


    }
}
