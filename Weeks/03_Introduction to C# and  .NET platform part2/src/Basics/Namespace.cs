


namespace Basics.Test
{
    public class Namespace : ISample
    {
        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}

namespace Basics
{
    namespace OtherTest
    {
        public class Namespace : ISample
        {
            public void Run()
            {
                throw new System.NotImplementedException();
            }
        }
    }

}

namespace MyNamespace
{
    class TEst
    {
        public TEst()
        {
            new Basics.Test.Namespace();
            new Basics.OtherTest.Namespace();
        }
    }
}