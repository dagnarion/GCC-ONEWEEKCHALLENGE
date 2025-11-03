using UnityEngine;
using DG.Tweening;
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
        rigi.velocity = new Vector2(horizontalVelocity, rigi.velocity.y);
    }

    public void Jump()
    {
        rigi.velocity = new Vector2(horizontalVelocity, Data.JumpForce);
    }

    void CheckGround()
    {
        IsOnGround = Physics2D.OverlapBox(CheckPoint.position, checkArea, 0, ground);
    }

    #region DrawCheckArea
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(CheckPoint.position, checkArea);
    }
    #endregion
}
