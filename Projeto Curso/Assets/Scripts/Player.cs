using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private float runningSpeed;
    private bool _IsRunning = false;
    private bool _IsRolling;
    private Rigidbody2D rig;
    private Vector2 _direction ;

    public Vector2 direction { get => _direction; set => _direction = value; }
    public bool IsRunning { get => _IsRunning; set => _IsRunning = value; }
    public bool IsRolling { get => _IsRolling; set => _IsRolling = value; }

    private void Start()
    {
        runningSpeed = speed * 1.5f;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnInput();
    }

    private void FixedUpdate()
    {
        OnRunOrWalk();
        OnRolling();
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    #region Movement

    private void OnRunOrWalk()
    {
        _IsRunning = Input.GetKey(KeyCode.LeftShift);
        if (_IsRunning)
        {
            OnMove(runningSpeed);
        }
        else
        {
            OnMove(speed);
        }
    }

    private void OnMove(float speed)
    {
        Vector2 mov = rig.position + direction * speed * Time.fixedDeltaTime;
        rig.MovePosition(mov);
    }

    private void OnRolling()
    {

        if (Input.GetMouseButtonDown(1))
        {
            _IsRolling = true;
        }
        else
        {
            _IsRolling = false;
        }
    }

    #endregion
}
