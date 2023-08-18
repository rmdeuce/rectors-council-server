namespace Application
{
    public abstract class Class1
    {
        private int _ = 0;

        public Class1(int a)
        {
            _ = a;
        }

        public int MyMethod()
        {
            return _;
        }
    }

    public class Class2 : Class1
    {
        public Class2(int a) : base(a)
        {
        }
    }
}