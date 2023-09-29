using System;
using UnityEngine;

namespace Management
{
	public class TimeManager : MonoSingleton<TimeManager>
	{

		[SerializeField] private float timePerTick = 10f;
		[SerializeField] private int ticksPerDay = 23;

		[SerializeField] private float currentTickCountdown;
		[SerializeField] private int currentDay;
		[SerializeField] private int currentTick;

		public float TimeSpeedFactor { get; set; } = 1f;

		public event Action OnTick;
		public event Action<int> OnDayUpdate;

		private void Setup()
		{
			currentTickCountdown = timePerTick;
			OnTick += DoTick;
		}

		private void DoTick()
		{

			if (currentTick > ticksPerDay)
			{			
				currentDay++;
				currentTick = 0;
				OnDayUpdate?.Invoke(currentDay);
			}
		}

		public void FixedUpdate()
		{
			if (currentTickCountdown < 0f)
			{
				currentTick++;
				OnTick?.Invoke();
				currentTickCountdown = timePerTick;
			}
			
			currentTickCountdown -= Time.fixedDeltaTime * TimeSpeedFactor;
			
		}
	}
}