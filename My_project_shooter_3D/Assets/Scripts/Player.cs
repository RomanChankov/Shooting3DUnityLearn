using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float speed;
    Cursor cursor;
    Shot shot;
    public Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    cursor = FindObjectOfType<Cursor>();
        navMeshAgent.updateRotation = false;
        shot = FindObjectOfType<Shot>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        // if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
        //     dir.z = 1.0f;
        // }
        // if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
        //     dir.z = -1.0f;
        // }
        // if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        //     dir.x = 1.0f;
        // }
        // if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        //     dir.x = -1.0f;
        // }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            dir.z = -1.0f;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            dir.z = 1.0f;
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            dir.x = -1.0f;
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            dir.x = 1.0f;
        }
        navMeshAgent.velocity = dir.normalized * speed;
        Vector3 forward = cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
        
        //Выстрел
        if(Input.GetMouseButtonDown(0)){
            var from = bullet.position;
            var target = cursor.transform.position;
            var to = new Vector3(target.x, from.y, target.z);
            var direction = (to-from).normalized;
            RaycastHit hit;
            if(Physics.Raycast(from, to-from, out hit,100)){
                to = new Vector3(hit.point.x, from.y, hit.point.z);
                //проверяем что есть объект в точке пересечения
                if(hit.transform != null) {
                    //если у этого щбъекта есть компонент зомби
                    var zombie = hit.transform.GetComponent<Zombie>();
                    if(zombie != null) {
                        zombie.Kill();
                    }
                }
            }else{
                to = from + direction*100;
            }
            shot.Show(from, to);
        }
    }
}
