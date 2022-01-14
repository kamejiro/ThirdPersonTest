using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //inspector�Őݒ�\��private�ϐ�
    //�Q�Ƃ̐ݒ�
    [SerializeField]
    private Transform pivot = null;

    void Start()
    {
        if (pivot == null) pivot = transform.parent;
    }

    //x���̉�](�c)�ɂ͐���������o�Ȃ��ƒn������]�����悤�Ɉړ�����B
    [Range(-0.999f, -0.5f)]
    public float minYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float maxYAngle = 0.5f;

    void Update()
    {
        //�}�E�X���́Bx_rote��local�ł���y,y_rote��local�ł���x
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        //x�͂��̂܂܉�]
        pivot.transform.Rotate(0, X_Rotation, 0);

        //y�͐����𒴂��Ȃ��͈͂ŉ�]
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
        //z�p������Ă���̂�z�̂�0�ŏ�����
        pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, 0f);


    }
}
