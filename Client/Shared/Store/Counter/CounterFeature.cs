using Fluxor;

namespace BlazorDemo.Client.Shared.Store.Counter
{
    public record CounterState(int Count);

    /// <summary>
    /// Feature is an area that provides a new piece of state for the Store. 
    /// To declare a feature, you would want to extend the abstract Feature<T> class available in Fluxor. 
    /// Feature<T> takes a state type.
    /// </summary>
    public class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => "Counter";

        protected override CounterState GetInitialState() => new (0);
    }
}
