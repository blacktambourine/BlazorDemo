using Fluxor;

namespace BlazorDemo.Client.Shared.Store.FetchData
{
    /// <summary>
    /// A reducer is a pure function that takes the current state and an action been dispatched upon it. 
    /// Depending on the action type, it produces a new state and returns it.
    /// </summary>
    public class FetchDataReducers
    {
        [ReducerMethod]
        public static FetchDataState ReduceFetchDataAction(FetchDataState state, FetchDataAction action) =>
       new(true, null, null);

        [ReducerMethod]
        public static FetchDataState ReduceFetchDataSuccessAction(FetchDataState state, FetchDataSuccessAction action) =>
            new(false, action.Forecast, null);

        [ReducerMethod]
        public static FetchDataState ReduceFetchDataErrorAction(FetchDataState state, FetchDataErrorAction action) =>
            new(false, null, action.ErrorMessage);
    }
}
