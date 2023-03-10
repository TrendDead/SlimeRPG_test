/// <summary>
/// Компонент движения игрока
/// </summary>
public class PlayerMove : BaseMove
{
    public override void Action(bool isAction)
    {
        Animation(isAction);
    }

}
