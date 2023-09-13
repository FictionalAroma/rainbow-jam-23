﻿using CommonComponents;
using CommonComponents.Interfaces;

namespace Management
{
	public class GameStateManager
	{
		private static GameStateManager _instance = null;
        public static GameStateManager Instance => _instance ??= new GameStateManager();

		private event GameStateChange StateChangeEvent;

		public GameState CurrentState { get; private set; } = GameState.Running;

		public void SetState(GameState state)
		{
			CurrentState = state;
			StateChangeEvent?.Invoke(state);
		}

		public void Subscribe(IGameStateSubscriber sub) => StateChangeEvent += sub.OnStateChange;
		public void Unsubscribe(GameStateModifier sub) { StateChangeEvent -= sub.OnStateChange; }
	}
}