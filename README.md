# Notifications

URA 插件：在育成结束且没有待处理事件时发送 Windows 通知。

## 行为

- 输入：宿主分发的 `single_mode/check_event` 响应。
- 条件：角色状态为 `2` 或 `3`，且 `unchecked_event_array` 为空或缺失。
- 输出：通过 Windows toast 显示通知；不修改响应。
- 平台：Windows 10 1809（版本 17763）或更高版本。

插件没有配置项。

## 构建

仓库通过 `NuGet.Config` 恢复 `UmamusumeResponseAnalyzer` 编译期包。`System.Drawing.Common` 的版本由本插件显式约束，覆盖通知工具包的传递依赖下限。

在仓库根执行：

```powershell
dotnet build .\Notifications.csproj -c Release -m:1 -p:RuntimeIdentifier=win-x64 -p:SelfContained=false -p:PlatformTarget=AnyCPU -p:DeployUraPluginToLocalAppDataOnBuild=false
```

`tests/NotificationsSmoke` 默认检查本仓发布边界，以及真实 Host 中初始化和未使用即释放时保持当前 workspace。测试工具源码由 `tests/Support/` 持有。

## 验证与发布

在 Windows 仓库根执行 `act workflow_dispatch --artifact-server-path "$env:TEMP/ura-act-artifacts"`。本地与 GitHub 使用同一份 workflow；版本 tag 触发 GitHub Release 发布。环境要求、共用 workflow 本地映射和发布规则见 [URA plugin workflows](https://github.com/URA-Plugins/.github/blob/v1/README.md)。
