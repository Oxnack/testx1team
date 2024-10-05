using UnityEngine;


public class OutputCubes : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private Life _life;

    private int _rows = 0;
    private int _columns = 0;

    private GameObject[,] _cubes;
    private Renderer[,] _rend;

    private void Start()
    {
        _rows = _life.rows;
        _columns = _life.columns;

        _cubes = new GameObject[_rows, _columns];
        _rend = new Renderer[_rows, _columns];

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                _cubes[i, j] = Instantiate(_cube, new Vector3(i, 0, j), Quaternion.identity);
                _rend[i, j] = _cubes[i, j].GetComponent<Renderer>();
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                if (_life.myArray[i, j] == 1)
                {
                    _rend[i, j].enabled = true; 
                }
                else
                {
                    _rend[i, j].enabled = false;
                }
            }
        }
    }

}
