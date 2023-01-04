namespace GymTracker.Features.Session;

public class CountdownTimerState
{
    public event Action? OnStateChange;

    private TimeSpan startDuration = new(0, 0, 3);
    private DateTime? startTime = null;
    
    private System.Timers.Timer timer = new(1);

    public TimeSpan TimeRemaining { get; private set; } = new();

    public CountdownTimerState()
    {
        timer.Elapsed += Timer_Elapsed;
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        TimeRemaining = startTime!.Value.Subtract(DateTime.UtcNow).Add(startDuration);
        OnStateChange?.Invoke();
    }

    public void StartTimer() => StartTimer(startDuration);
    public void StartTimer(TimeSpan startDuration)
    {
        this.startDuration = startDuration;
        this.startTime = DateTime.UtcNow;

        timer.Start();
    }

    public void StopTimer() => timer.Stop();
}
