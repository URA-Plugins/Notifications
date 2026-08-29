# Notifications

URA 插件：在育成结束且没有待处理事件时发送 Windows 通知。

## 行为

- 输入：宿主分发的 `single_mode/check_event` 响应。
- 条件：角色状态为 `2` 或 `3`，且 `unchecked_event_array` 为空或缺失。
- 输出：通过 Windows toast 显示通知；不修改响应。
- 平台：Windows 10 1809（版本 17763）或更高版本。

插件没有配置项。

## 构建

仓库通过 Git submodule 固定 Host 源码。克隆后在仓库根执行：

```powershell
git -c core.longpaths=true submodule update --init --recursive
dotnet build .\Notifications.csproj -c Release -m:1 -p:RuntimeIdentifier=win-x64 -p:SelfContained=false -p:PlatformTarget=AnyCPU -p:DeployUraPluginToLocalAppDataOnBuild=false
```
