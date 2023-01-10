using Fluxor;
using System.Timers;

namespace GymTracker.Features.Session.CountdownTimer.Store;

public class CountdownTimerEffects
{
    private System.Timers.Timer _timer = new(1);
    private readonly IState<CountdownTimerState> _state;
    private IDispatcher _dispatcher;

    public CountdownTimerEffects(IState<CountdownTimerState> state, IDispatcher dispatcher)
    {
        _state = state;
        _dispatcher = dispatcher;
        _timer.Elapsed += onTimerElapsed;
    }

    private void onTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        var currentState = _state.Value;

        if (currentState.StartTime is null)
            return;

        var duration = currentState.StartTime.Value.Subtract(DateTime.UtcNow).Add(currentState.StartDuration);

        _dispatcher.Dispatch(new CountdownTimerSetDurationAction(Duration: duration));
    }

    [EffectMethod]
    public Task OnStart(CountdownTimerStartAction action, IDispatcher dispatcher)
    {
        _timer.Start();
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task OnStart(CountdownTimerStartWithDurationAction action, IDispatcher dispatcher)
    {
        _timer.Start();
        return Task.CompletedTask;
    }
}
