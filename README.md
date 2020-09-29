# IOptionsMonitorBug
Demonstrates a bug with `IOptionsMonitor&lt;T>` in ASP.NET Core 3.1

TO REPRODUCE THE ISSUE:
1) Run the website
2) Hit the `/ping` endpoint from a browser - e.g. `https://localhost:5001/ping`
3) Observer that `"MyValue = foo"` is printed to the Console - `"foo"` is the value from appsettings.json
4) While the site is running, change the value of `"foo"` in appsettings.json to `"bar"`
5) Hit the `/ping endpoint` again from a browser - e.g. `https://localhost:5001/ping`
6) Observe that `"MyValue - foo"` is printed to the Console again. This value is stale

EXPECTED RESULT:
`"MyValue = bar"` should be printed to the Console, since that is the latest value in configuration and `IOptionsMonitor<T> `should have detected the change to the file.

ACTUAL RESULT:
The stale value `"MyValue = foo"` is printed.

OTHER NOTES:
If you look at `Startup.cs` - lines 16/17 - if you use `GetSection` (line 17) instead of `Bind` (line 16), then things work as expected - the change of configuration value to `"bar"` is detected. I believe it should also work as desired using `Bind`.
