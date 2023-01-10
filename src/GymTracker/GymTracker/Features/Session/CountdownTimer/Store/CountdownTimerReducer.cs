using Fluxor;

namespace GymTracker.Features.Session.CountdownTimer.Store;

public static class CountdownTimerReducer
{
    [ReducerMethod]
    public static CountdownTimerState OnStart(CountdownTimerState state, CountdownTimerStartAction action)
    {
        return state with
        {
            StartTime = action.StartTime
        };
    }

    [ReducerMethod]
    public static CountdownTimerState OnStart(CountdownTimerState state, CountdownTimerStartWithDurationAction action)
    {
        return state with
        {
            StartTime = action.StartTime,
            StartDuration = action.Duration
        };
    }

    [ReducerMethod]
    public static CountdownTimerState OnSetDuration(CountdownTimerState state, CountdownTimerSetDuration action)
    {
        return state with
        {
            Duration = action.Duration
        };
    }
}
