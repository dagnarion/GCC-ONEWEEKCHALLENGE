
public class PlayerJump : IState
{
    PlayerController player;
    public PlayerJump(PlayerController _player)
    {
        player = _player;
    }
    public void Enter()
    {
        player.Movement.Jump();
        player.ani.Play("Jump");
    }

    public void LogicUpdate()
    {
        player.Movement.Move(); 
        if (player.Movement.IsJumpDone() || InputManager.Instance.IsJumpReleased)
        {
            player.StateMC.ChangeState<PlayerOnAir>();
            return;
        }
    }

    public void PhysicsUpdate()
    {

    }

    public void Exit()
    {

    }
}
