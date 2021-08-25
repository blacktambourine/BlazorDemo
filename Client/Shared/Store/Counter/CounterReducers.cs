using Fluxor;

namespace BlazorDemo.Client.Shared.Store.Counter
{
    /// <summary>
    /// A reducer is a pure function that takes the current state and an action been dispatched upon it. 
    /// Depending on the action type, it produces a new state and returns it.
    /// </summary>
    public class CounterReducers
    {
        //Reduce 
        [ReducerMethod]
        public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
       state with { Count = state.Count + 1 };

        //Reduce By
        [ReducerMethod]
        public static CounterState ReduceIncrementCounterByAction(CounterState state, IncrementCounterByAction action) =>
               state with { Count = state.Count + action.IncrementBy };
    }
}
