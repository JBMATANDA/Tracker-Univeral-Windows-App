#pragma once
#pragma once
namespace Background_Task
{
	[Windows::Foundation::Metadata::WebHostHidden]
	public ref class LocationBackgroundTask sealed : public Windows::ApplicationModel::Background::IBackgroundTask
	{
	public:
		LocationBackgroundTask();

		virtual void Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance^ taskInstance);

	private:
		void OnCanceled(Windows::ApplicationModel::Background::IBackgroundTaskInstance^ taskInstance, Windows::ApplicationModel::Background::BackgroundTaskCancellationReason reason);
		~LocationBackgroundTask();

		Concurrency::cancellation_token_source geopositionTaskTokenSource;
	};
}

