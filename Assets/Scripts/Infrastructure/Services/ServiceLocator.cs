using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Services;

public class ServiceLocator
{
    private Dictionary<Type, IService> _services;

    public ServiceLocator()
    {
        _services = new Dictionary<Type, IService>();
    }

    public void RegisterService<TService>(TService service) where TService: IService
    {
        if (_services.ContainsKey(typeof(TService)))
        {
            throw new Exception($"ServiceLocator has already had the service, you want to add: {typeof(TService)}");
        }
        _services[typeof(TService)] = service;

    }

    public TService GetService<TService>() where TService : class, IService
    {
        if (_services.ContainsKey(typeof(TService)))
        {
            return  _services[typeof(TService)] as TService;
        }
        else
        {
            throw new Exception($"ServiceLocator has no service: {typeof(TService)}");
        }
    }
}
