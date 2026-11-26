---
title: Service Implementation Handlers Guidance
address: method/project-design/service-implementation-handlers
owner: agent/sa
version: 1.0.0
last_updated: 2026-11-25
---

# Service Implementation Handlers Guidance

## Goal
Reduce the public surface area of a service implementation class while keeping the code base type‑safe and easily extensible.  The pattern uses **generic entry points** that delegate to **typed handler components** registered in the DI container.

## Pattern
```csharp
public interface IHandler<TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken ct);
}

public class MyService : IMyService
{
    private readonly IServiceProvider _sp;

    public MyService(IServiceProvider sp) => _sp = sp;

    public async Task<FindResponse<T>> FindAsync<T>(FindRequest request, CancellationToken ct)
        where T : class
    {
        // Resolve the concrete handler for the requested payload type.
        var handler = (IHandler<FindRequest, FindResponse<T>>)_sp.GetRequiredService(
            typeof(IHandler<FindRequest, FindResponse<T>>));
        return await handler.HandleAsync(request, ct);
    }

    // Additional generic methods (CreateAsync<T>, UpdateAsync<T>, DeleteAsync<T>) follow the same shape.
}
```

### Handler registration (DI container example)
```csharp
services.AddTransient<IHandler<FindRequest, FindResponse<Customer>>, CustomerFindHandler>();
services.AddTransient<IHandler<FindRequest, FindResponse<Order>>, OrderFindHandler>();
// …register each capability you expose.
```

## Why it satisfies Lowy’s “limited component surface area”
* **Explicit contract** – each handler implements a single capability (`IHandler<…, …>`). The service class only knows the generic method signature; the concrete surface is defined by the handler registrations.
* **Encapsulation** – business rules stay inside the handler. The service class does **no** domain logic; it merely routes the call.
* **Governance‑ready** – the validator can verify that every generic method used in a service has a matching handler registration entry in a configuration file (`governance‑validator.json` can be extended to check this). This makes the component surface auditable.
* **Portable** – because the handler type is resolved at runtime, the compiled service binary does not contain direct references to domain libraries. Moving the service to a different solution only requires the appropriate handler implementations to be present, preserving portability.

## Checklist for Solution Architects (add to *System Design* section)
- [ ] Service classes expose **generic** async methods (e.g., `FindAsync<T>`). 
- [ ] For each generic method, a **handler interface** (`IHandler<Req,Res<T>>`) is defined. 
- [ ] All concrete handlers are **registered** in the DI container and listed in a governance artefact (`handler‑registry.yaml`).
- [ ] The validator is configured to ensure **no missing handler** for any generic method used in the service.
- [ ] Documentation of the mapping (`T` → `*Handler`) is included in the system‑design diagram.

## Related artefacts
- `docs/the-method/project-design/project-design.md` – reference the pattern under *System Design*.
- `docs/the-method/checklists/solution-architect-checklist.md` – checklist items added automatically by this guidance.
- `tools/governance-validator/governance-validator.json` – optional `handlerRegistryPath` key to point to the YAML file that lists all handler registrations.

---

*This guidance follows Juval Lowy’s Method by keeping component boundaries explicit, limiting surface area, and making the design verifiable through governance artefacts.*
