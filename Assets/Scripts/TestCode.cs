using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    //��Ʈ�� + ����+ �����̽� �����ε��� �Ű����� Ȯ�� ����
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision!!!!!{collision.gameObject.name}");
    }
    /*
        1. �� �� Collider�� �־�� �Ѵ�.
        2. �� �� �ϳ��� IsTrigger : On
        3. �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
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
        // ��Ʈ�� + ����Ʈ + �����̽���: �����ε��� �Ű����� Ȯ�� ����
        //Vector3 Look = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position + Vector3.up, Look * 10, Color.red);
        //// ����ĳ��Ʈ�� ��� ��� ������ ������
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, Look, 10);
        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log($"Raycast {hit.collider.gameObject.name}!!");
        //}

        // ����ĳ��Ʈ�� ��� ù ��° ��ü �������� ������
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position + Vector3.up, Look, out hit, 10))
        //{
        //    Debug.Log($"Raycast{hit.collider.gameObject.name}!!!");
        //}

        // ���콺 ���� ĳ����
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        //    // �� Ray ���ذ� �Ʒ� ���� �� ���ذ���
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
