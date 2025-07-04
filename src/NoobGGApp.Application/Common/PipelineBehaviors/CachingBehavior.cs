﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NoobGGApp.Application.Attributes;
using NoobGGApp.Application.Common.Interfaces;
using StackExchange.Redis;
using System;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheable
{
    private readonly IDistributedCache _cache;
    private readonly ICacheKeyFactory _cacheKeyFactory;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;
    private readonly IDatabase _redisDb;
    private static readonly DistributedCacheEntryOptions _defaultCacheOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
        SlidingExpiration = TimeSpan.FromMinutes(15)
    };

    public CachingBehavior(
        IDistributedCache cache,
        ICacheKeyFactory cacheKeyFactory,
        ILogger<CachingBehavior<TRequest, TResponse>> logger,
        IConnectionMultiplexer redis)
    {
        _cache = cache;
        _cacheKeyFactory = cacheKeyFactory;
        _logger = logger;
        _redisDb = redis.GetDatabase();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cacheKey = _cacheKeyFactory.CreateCacheKey(request);

        var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrEmpty(cachedData))
        {
            _logger.LogInformation($"[Cache Hit] Key: {cacheKey}");

            return JsonSerializer.Deserialize<TResponse>(cachedData);
        }

        _logger.LogInformation($"[Cache Miss] Key: {cacheKey}. Fetching from database.");

        var response = await next();

        var serializedResponse = JsonSerializer.Serialize(response);

    
        var cacheOptions = GetCacheOptionsFromAttribute() ?? _defaultCacheOptions;

        await _cache.SetStringAsync(cacheKey, serializedResponse, cacheOptions, cancellationToken);

    
        if (!string.IsNullOrEmpty(request.CacheGroup))
        {
            var groupSetKey = $"Group:{request.CacheGroup}";

            await _redisDb.SetAddAsync(groupSetKey, cacheKey);
        }

        return response;
    }

    private DistributedCacheEntryOptions? GetCacheOptionsFromAttribute()
    {
        var attribute = typeof(TRequest).GetCustomAttribute<CacheOptionsAttribute>();

        if (attribute is null)
            return null;

        var options = new DistributedCacheEntryOptions();

        if (attribute.AbsoluteExpirationRelativeToNow.HasValue)
            options.AbsoluteExpirationRelativeToNow = attribute.AbsoluteExpirationRelativeToNow;

        if (attribute.SlidingExpiration.HasValue)
            options.SlidingExpiration = attribute.SlidingExpiration;

        return options;
    }
}