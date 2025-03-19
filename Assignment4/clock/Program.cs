using System;
using System.Timers;

class AlarmClock
{
    public event Action? Tick;  // 嘀嗒事件
    public event Action? Alarm; // 闹钟事件

    private System.Timers.Timer timer;
    private DateTime alarmTime;

    public AlarmClock()
    {
        timer = new System.Timers.Timer(1000); // 1秒触发一次
        timer.Elapsed += (sender, e) => OnTick();
    }

    public void SetAlarm(DateTime alarmTime)
    {
        this.alarmTime = alarmTime;
    }

    public void Start()
    {
        timer.Start();
        Console.WriteLine("闹钟已启动...");
    }

    public void Stop()
    {
        timer.Stop();
        Console.WriteLine("闹钟已停止...");
    }

    protected virtual void OnTick()
    {
        Tick?.Invoke();
        Console.WriteLine($"当前时间：{DateTime.Now:HH:mm:ss}");

        // 判断是否到达设定的闹钟时间
        if (DateTime.Now >= alarmTime)
        {
            OnAlarm();
        }
    }

    protected virtual void OnAlarm()
    {
        Alarm?.Invoke();
        Console.WriteLine(" 闹钟响了！");
        Stop();  // 触发闹钟后停止计时
    }
}

class Program
{
    static void Main()
    {
        AlarmClock clock = new AlarmClock();

        // 订阅 Tick 事件
        clock.Tick += () => Console.WriteLine(" 嘀嗒...");

        // 订阅 Alarm 事件
        clock.Alarm += () => Console.WriteLine(" 铃铃铃！时间到了！");

        // 设置闹钟时间（5秒后响铃）
        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        clock.SetAlarm(alarmTime);

        // 启动闹钟
        clock.Start();

        // 防止主线程退出
        Console.ReadLine();
    }
}
