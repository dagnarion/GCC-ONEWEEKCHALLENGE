using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerDataSO Data;
    [SerializeField] Collider2D coll;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector3 checkArea;
    [SerializeField] Transform CheckPoint;
    Rigidbody2D rigi;
    public bool IsOnGround { get; private set; }
    public bool IsOnObstacle { get; private set; }
    float horizontalVelocity;
    public int NumberOfJumpHadUsed { get; private set; }
    [SerializeField] float subSpeed;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckGround();
        Debug.Log(NumberOfJumpHadUsed);
    }

    public void Move()
    {
        float moveFlag = InputManager.Instance.PlayerMove;
        if (IsOnGround)
        {
            if (moveFlag > 0)
            {
                horizontalVelocity = Mathf.Lerp(horizontalVelocity, Data.MaxSpeed * moveFlag, Data.Acceleration * Time.deltaTime);
            }
            else
                if (moveFlag < 0) horizontalVelocity = Mathf.Lerp(horizontalVelocity, -Data.MaxSpeed * 0.75f, Data.Deceleration * Time.deltaTime);
            if (moveFlag == 0) horizontalVelocity = 0;
        }
        else
        {
            if (moveFlag != 0)
            {
                horizontalVelocity = Mathf.Lerp(horizontalVelocity, Data.MaxSpeed * moveFlag, Data.Acceleration * Time.deltaTime);
            }
            else horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, Data.Acceleration * Time.deltaTime);
        }
        rigi.velocity = new Vector2(horizontalVelocity + subSpeed, rigi.velocity.y);
    }

    public void Jump()
    {
        NumberOfJumpHadUsed++;
        rigi.velocity = new Vector2(horizontalVelocity, Data.JumpForce);
    }

    public void ResetNumberOfJump() => NumberOfJumpHadUsed = 1;

    public bool IsJumpDone() => rigi.velocity.y <= 0f;
    void CheckGround()
    {
        Collider2D check = Physics2D.OverlapBox(CheckPoint.position, checkArea, 0, ground);
        IsOnGround = check;
        if (check != null && check.CompareTag("Obstacle"))
        {
            subSpeed = check.gameObject.GetComponent<Obstacle>().GetVelocity.x;
            IsOnObstacle = true;
        }
        else
        {
            IsOnObstacle = false;
            subSpeed = 0;
        }
    }

    #region DrawCheckArea
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(CheckPoint.position, checkArea);
    }
    #endregion
}
