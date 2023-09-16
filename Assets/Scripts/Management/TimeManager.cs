using System;
using UnityEngine;

namespace Management
{
	public class TimeManager : MonoBehaviour
	{
		public static TimeManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
				DontDestroyOnLoad(this);
				Setup();
			} 
		}


		[SerializeField] private float timePerTick = 10f;
		[SerializeField] private int ticksPerDay = 23;

		[SerializeField] private float currentTickCountdown;
		[SerializeField] private int currentDay;
		[SerializeField] private int currentTick;

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
			else
			{
				currentTickCountdown -= Time.fixedDeltaTime;
			}
		}
	}
}