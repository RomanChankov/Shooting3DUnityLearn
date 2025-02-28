using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int layerMask;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        layerMask = LayerMask.GetMask("Ground");
    }

        void Update()
    {
        //Выпускаем луч из точки нахождения курсора на экране
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Если нет пересечений со слоем Ground
        if (!Physics.Raycast(ray, out hit, 1000, layerMask)){
            //отключаем отображение курсора
            spriteRenderer.enabled = false;
        }else{
            //Задаем курсору позицию по координатам пересечения с поверхностью
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            spriteRenderer.enabled = true;
        }
    }
}
