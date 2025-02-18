using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapDistanceKm = 50.0 / 1000.0;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapDistanceKm;
    }

    public override double GetSpeed()
    {
        double distanceInKm = GetDistance();
        return (distanceInKm / _minutes) * 60;
    }

    public override double GetPace()
    {
        double distanceInKm = GetDistance();
        return _minutes / distanceInKm;
    }
}