﻿using System.Diagnostics;

namespace PolicyManagment.Middleware;

public class Logging
{
    private readonly RequestDelegate _next;
    private readonly ILogger<Logging> _logger;


    public Logging(RequestDelegate next, ILogger<Logging> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();//start a stopwatch to calculate how long the request takes

        _logger.LogInformation("Request :{method}{url}", context.Request.Method, context.Request.Path);

        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation(" Response: {statusCode} in {elapsed} ms",
           context.Response.StatusCode,
           stopwatch.ElapsedMilliseconds);
    }
}
