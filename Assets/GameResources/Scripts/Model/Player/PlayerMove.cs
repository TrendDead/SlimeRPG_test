/// <summary>
/// Компонент движения игрока
/// </summary>
public class PlayerMove : BaseMove
{
    public override void Action(bool isAction)
    {
        if(!isAction)
        {
            Animation();
        }
    }

    protected override void Animation()
    {
        //зфпустить анимацию движения
        
    }

}
