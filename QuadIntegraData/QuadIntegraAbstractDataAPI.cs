namespace QuadIntegraData
{
    public abstract class QuadIntegraAbstractDataAPI
    {
        public QuadIntegraAbstractDataAPI() { }
        public static QuadIntegraAbstractDataAPI CreateInstance()
        {
            return new QuadIntegraDataAPI();
        }

        public abstract Func<double, double> GetFunction(int index);
        public abstract (double, double)[] GetGLQuadratureData(int quadratureNodesNumber, double a, double b);
    }
}