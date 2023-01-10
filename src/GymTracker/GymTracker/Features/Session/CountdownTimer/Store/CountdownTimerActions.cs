namespace GymTracker.Features.Session.CountdownTimer.Store;

public record CountdownTimerStartAction(DateTime StartTime);
public record CountdownTimerStartWithDurationAction(DateTime StartTime, TimeSpan Duration);
public record CountdownTimerSetDuration(TimeSpan Duration);