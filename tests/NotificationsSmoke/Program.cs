RepositoryChecks.Run();
using var ui = new WorkspaceSmokeSession();
PluginLifecycleSmoke.Run(ui);
