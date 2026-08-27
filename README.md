# Notifications

URA 插件：在育成结束且没有待处理事件时发送 Windows 通知。

## 行为

- 输入：宿主分发的 `single_mode/check_event` 响应。
- 条件：角色状态为 `2` 或 `3`，且 `unchecked_event_array` 为空或缺失。
- 输出：通过 Windows toast 显示通知；不修改响应。
- 平台：Windows 10 1809（版本 17763）或更高版本。

插件没有配置项。

## 构建

在仓库根目录执行：

```powershell
dotnet build Notifications.csproj -p:GenerateUraPluginManifestOnBuild=false -p:PackageUraPluginOnBuild=false -p:DeployUraPluginToLocalAppDataOnBuild=false
```

项目依赖 `<ura-host-project>` 提供的 URA 插件构建约定和宿主契约。
