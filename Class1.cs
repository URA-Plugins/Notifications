using Gallop;
using Gallop.Endpoints;
using Microsoft.Toolkit.Uwp.Notifications;
using UmamusumeResponseAnalyzer.Plugin;

namespace Notifications
{
    public class Notifications : IPlugin
    {
        public void Initialize(IPluginContext context) { }

        [ResponseAnalyzer<GameApi.SingleMode.CheckEvent>]
        public ValueTask OnTrainingFinish(SingleModeCheckEventResponse response)
        {
            var data = response.data;
            var charaInfo = data.chara_info;
            if (charaInfo.state is 2 or 3 && data.unchecked_event_array is null or { Length: 0 })
            {
                new ToastContentBuilder()
                    .AddText("育成结束力！")
                    .Show();
            }

            return ValueTask.CompletedTask;
        }
    }
}
