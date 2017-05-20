# ASP.NET WebAPI: OWIN Self-Host Logging

See [Use OWIN to Self-Host ASP.NET Web API 2 - Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api)

This sample use [log4net](https://logging.apache.org/log4net/).

## Configure log4net
See [Apache log4net Manual - Configuration](https://logging.apache.org/log4net/release/manual/configuration.html)  
In this sample, the log4net configuration added to `app.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>

  <!-- other configuration -->

  <log4net>
    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender" >
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
      </layout>
    </appender>
    <root>
      <level value="DEBUG" />
      <appender-ref ref="ConsoleAppender" />
    </root>
  </log4net>

  <!-- other configuration -->

</configuration>
```
**NOTE**: `<configSections>` must be the first element of `<configuration>`.  

Then, call the `XmlConfigurator.Configure()`. I encapsulate it into the `CreateLog4NetLogger()` extension method:

```CSharp
app.CreateLog4NetLogger();
```

## Use DelegatingHandler to logging request and response
Add `LoggingRequestHandler` to `HttpConfiguration`:

```CSharp
config.MessageHandlers.Add(new LoggingRequestHandler());
```

## Use Middleware to logging errors
Use `HandlerErrorMiddleware`, and make sure it's the first middleware in `Configuration()`:

```CSharp
app.Use<HandlerErrorMiddleware>();
```