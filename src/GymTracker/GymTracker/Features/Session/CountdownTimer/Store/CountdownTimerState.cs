using Fluxor;

namespace GymTracker.Features.Session.CountdownTimer.Store;

[FeatureState]
public record CountdownTimerState
{
    public DateTime? StartTime { get; init; } = null;
    public TimeSpan StartDuration { get; init; } = TimeSpan.FromMilliseconds(2500);
    public TimeSpan Duration { get; init; } = TimeSpan.FromMilliseconds(2500);
}
