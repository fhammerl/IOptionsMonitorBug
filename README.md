# IOptionsMonitorBug
Demonstrates a bug with IOptionsMonitor&lt;T> in ASP.NET Core 3.1

TO REPRODUCE THE ISSUE:
1) Run the website
2) Hit the /ping endpoint from a browser - e.g. https://localhost:44313/ping
3) Note that "foo" is printed to the Console - this is the value from appsettings.json
4) While the site is running, change the value of "foo" in appsettings.json to "bar"
5) Hit the /ping endpoint from a browser - e.g. https://localhost:44313/ping
6) Observe that "foo" is printed to the Console. This value is stale

EXPECTED RESULT:
"bar" should be printed to the Console, since that is the latest value in configuration and IOptionsMonitor<T> should have detected the change to the file.

ACTUAL RESULT:
The stale value "foo" is printed.

OTHER NOTES:
If you change Startup.cs - lines 16/17 - if you use "GetSection" instead of "Bind", then things work as expected - the change of configuration value to "bar" is detected.