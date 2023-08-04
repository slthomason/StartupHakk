.UsePackageHandler(async (session, package) =>
{
    var result = 0;

    switch (package.Key.ToUpper())
    {
        case ("ADD"):
            result = package.Parameters
                .Select(p => int.Parse(p))
                .Sum();
            break;

        case ("SUB"):
            result = package.Parameters
                .Select(p => int.Parse(p))
                .Aggregate((x, y) => x - y);
            break;

        case ("MULT"):
            result = package.Parameters
                .Select(p => int.Parse(p))
                .Aggregate((x, y) => x * y);
            break;
    }

    await session.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
})