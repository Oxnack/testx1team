using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private Life _life;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���������, ���� �� ������ ����� ������ ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // ������� ��� � ���������, ������ �� �� �� �������
            {
                if (hit.collider.gameObject.CompareTag("Cube")) // ���������, ����� �� ������ ��� "Cube"
                {
                    int i = Mathf.RoundToInt(hit.collider.gameObject.transform.position.x);
                    int j = Mathf.RoundToInt(hit.collider.gameObject.transform.position.z);

                    if (_life.myArray[i, j] == 1)
                    {
                        _life.SetLife(i, j, 0);
                    }
                    else
                    {
                        _life.SetLife(i, j, 1);
                    }
                }
            }
        }

    }
}
