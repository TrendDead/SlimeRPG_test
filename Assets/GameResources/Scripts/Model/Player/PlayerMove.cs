/// <summary>
/// ��������� �������� ������
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
        //��������� �������� ��������
        
    }

}
