using LightBDD.Results;

namespace LightBDD.Notification
{
	/// <summary>
	/// Interface for progress notification.
	/// </summary>
	public interface IProgressNotifier
	{
		/// <summary>
		/// Notifies that feature has been started.
		/// </summary>
		/// <param name="featureName">Feature name.</param>
		/// <param name="featureDescription">Feature description.</param>
		/// <param name="label">Feature label.</param>
		void NotifyFeatureStart(string featureName, string featureDescription, string label);

		/// <summary>
		/// Notifies that scenario has been finished with given status.
		/// </summary>
		/// <param name="status">Status.</param>
		void NotifyScenarioFinished(ResultStatus status);

		/// <summary>
		/// Notifies that scenario has been started.
		/// </summary>
		/// <param name="scenarioName">Scenario name.</param>
		/// <param name="label">Scenario label.</param>
		void NotifyScenarioStart(string scenarioName, string label);

		/// <summary>
		/// Notifies that step has been started.
		/// </summary>
		/// <param name="stepName">Step name.</param>
		/// <param name="stepNumber">Step number starting from 1.</param>
		/// <param name="totalStepCount">Total number of steps.</param>
		void NotifyStepStart(string stepName, int stepNumber, int totalStepCount);
	}
}