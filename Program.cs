using Microsoft.Azure.SignalR.Management;

string connectionString =
    "Endpoint=https://signalrtest321.service.signalr.net;AccessKey=AXs17lUU8Mda7r80A92I1tN9thgcGAFOSKaiZN8FbNUqIpf6NAxXJQQJ99CFAC5RqLJXJ3w3AAAAASRSkVel;Version=1.0;";

var serviceManager =
    new ServiceManagerBuilder()
    .WithOptions(options =>
    {
        options.ConnectionString =
            connectionString;
    })
    .BuildServiceManager();

await using var hubContext =
    await serviceManager
        .CreateHubContextAsync("cti", CancellationToken.None);

var negotiate =
    await hubContext
        .NegotiateAsync();

Console.WriteLine("URL:");
Console.WriteLine(negotiate.Url);

Console.WriteLine();
Console.WriteLine("TOKEN:");
Console.WriteLine(negotiate.AccessToken);

Console.WriteLine();
Console.WriteLine("FULL URL:");

Console.WriteLine(
    $"{negotiate.Url}?hub=cti&access_token={negotiate.AccessToken}"
);
