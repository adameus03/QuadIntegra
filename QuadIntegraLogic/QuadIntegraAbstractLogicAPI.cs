namespace QuadIntegraLogic
{
    public abstract class QuadIntegraAbstractLogicAPI
    {
        protected readonly QuadIntegraData.QuadIntegraAbstractDataAPI dataAPI;

        public QuadIntegraAbstractLogicAPI(QuadIntegraData.QuadIntegraAbstractDataAPI? dataAPI = null)
        {
            this.dataAPI = dataAPI ?? QuadIntegraData.QuadIntegraAbstractDataAPI.CreateInstance();
        }

        public static QuadIntegraAbstractLogicAPI CreateInstance(QuadIntegraData.QuadIntegraAbstractDataAPI? dataAPI = null)
        {
            return new QuadIntegraLogicAPI(dataAPI ?? QuadIntegraData.QuadIntegraAbstractDataAPI.CreateInstance());
        }

        public event EventHandler<QuadIntegraData.ComputationDumpEventArgs> ComputationDump;
        protected void OnComputationDump(object? sender, QuadIntegraData.ComputationDumpEventArgs computationDumpEventArgs)
        {
            this.ComputationDump?.Invoke(sender, computationDumpEventArgs);
        }

        public abstract double Integrate<TIntegrator>(int functionIndex, double integrationLeftBound, 
                                                      double integrationRightBound, double desiredAccuracy, IntegratorInfo? integratorInfo = null) where TIntegrator : Integrator;

        public (double, double)[] GetNodes(int quadratureNodesNumber, double integrationLeftBound, double integrationRightBound) => this.dataAPI.GetGLQuadratureData(quadratureNodesNumber, integrationLeftBound, integrationRightBound);
        public Func<double, double> Function(int index) => this.dataAPI.GetFunction(index);
        public QuadIntegraData.QuadIntegraAbstractDataAPI DataAPI => this.dataAPI;
    }
}