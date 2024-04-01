using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    //컨트롤 + 쉬프+ 스페이스 오버로딩된 매개변수 확인 가능
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision!!!!!{collision.gameObject.name}");
    }
    /*
        1. 둘 다 Collider가 있어야 한다.
        2. 둘 중 하나는 IsTrigger : On
        3. 둘 중 하나는 RigidBody가 있어야 한다.
     */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger!!!!!{other.gameObject.name}");
    }
    void Start()
    {

    }
        void Update()
    {
        // 컨트롤 + 쉬프트 + 스페이스바: 오버로딩된 매개변수 확인 가능
        //Vector3 Look = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position + Vector3.up, Look * 10, Color.red);
        //// 레이캐스트에 닿는 모든 정보를 가져옴
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, Look, 10);
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log($"Raycast {hit.collider.gameObject.name}!!");
        //}

        // 레이캐스트에 닿는 첫 번째 객체 정보만을 가져옴
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position + Vector3.up, Look, out hit, 10))
        //{
        //    Debug.Log($"Raycast{hit.collider.gameObject.name}!!!");
        //}

        // 마우스 레이 캐스팅
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        //    // 위 Ray 해준게 아래 세줄 다 해준거임
        //    //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    //Vector3 dir = mousePos - Camera.main.transform.position;
        //    //dir = dir.normalized;
        //    Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;
        //    int mask = (1 << 6) | (1 << 7);

        //    if(Physics.Raycast(ray, out hit, 100.0f, mask))
        //    {
        //        Debug.Log($"RayCast{hit.collider.gameObject.name}!@!@!");
        //    }

        //    //if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hit, 100.0f))
        //    //{
        //    //    Debug.Log($"RayCast{hit.collider.gameObject.name}!@!@!");
        //    //}
        //}
    }
}
