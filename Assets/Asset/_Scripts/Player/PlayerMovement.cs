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
    float horizontalVelocity;
    [SerializeField] float subSpeed;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckGround();
    }

    public void Move()
    {
        float moveFlag = InputManager.Instance.PlayerMove;
        if (moveFlag != 0)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, Data.MaxSpeed * moveFlag, Data.Acceleration * Time.deltaTime);
        }
        else horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, Data.Deceleration * Time.deltaTime);
        rigi.velocity = new Vector2(horizontalVelocity+subSpeed, rigi.velocity.y);
    }

    public void Jump()
    {
        rigi.velocity = new Vector2(horizontalVelocity, Data.JumpForce);
    }

    void CheckGround()
    {
        Collider2D check = Physics2D.OverlapBox(CheckPoint.position, checkArea, 0, ground);
        IsOnGround = check;
        if (check != null && check.CompareTag("Obstacle"))
        {
            subSpeed = check.gameObject.GetComponent<Obstacle>().GetVelocity.x;
        }
        else subSpeed = 0;
    }

    #region DrawCheckArea
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(CheckPoint.position, checkArea);
    }
    #endregion
}
