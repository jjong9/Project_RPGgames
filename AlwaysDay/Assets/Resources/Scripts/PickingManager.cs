using UnityEngine;
using System.Collections;

public class PickingManager : MonoBehaviour
{
    public Shader baseShader;   //기본 쉐이더
    public Shader changeShader; //선택 되었을때 바꿔 줄 쉐이더
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //현재 마우스클릭한 위치

            Renderer renderer = this.gameObject.GetComponentInChildren<Renderer>();
            //캐릭터에는 충돌체가 있어야 픽킹될 수 있다.

            if (Physics.Raycast(ray, out hit) == true) //피킹이 되면 hit 피킹된 오브젝트정보가 달려온다.
            {
                //자신만이 피킹 되면 쉐이더를 교체한다.
                if (hit.collider.gameObject == this.gameObject)
                    renderer.material.shader = changeShader;
                else
                    renderer.material.shader = baseShader;
            }
            else
            {
                renderer.material.shader = baseShader;
            }
        }
    }
}
