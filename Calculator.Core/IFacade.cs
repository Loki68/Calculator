namespace Calculator.Core
{
    public interface IFacade
    {
        string Code { get; set; }
        double Calculate();
    }
}
