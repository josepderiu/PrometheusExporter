# Prometheus Learning Project

This is a learning project that uses Prometheus for monitoring and telemetry in an ASP.NET Core application.

## Project Structure

The project consists of two main parts:

1. `Host`: This is the ASP.NET Core application that we are monitoring. It contains a simple API with a weather forecast endpoint and health metrics.

2. `Host.IntegrationTests`: This project contains integration tests for the `Host` application.

## Using Prometheus

Prometheus is used to collect metrics from the `Host` application. These metrics are exposed at the `/metrics` endpoint and can be collected by a Prometheus server.

The `prometheus-net.AspNetCore.HealthChecks` NuGet package is used in this project to expose health checks from the ASP.NET Core application. This package integrates with the `prometheus-net` library to also expose these health checks as metrics that can be scraped by a Prometheus server.

While OpenTelemetry is a more recent and more general solution that supports multiple telemetry systems, including Prometheus, it can be more complex to set up and use if you only need support for Prometheus. `prometheus-net.AspNetCore.HealthChecks` is a simpler and more direct option if you only need support for Prometheus. It allows you to expose both health checks and metrics from your application that Prometheus can scrape directly, without the need to set up additional exporters or adapters.

## How to Run the Project

To run the project, you will need Docker and Docker Compose. Once you have these installed, you can run the project with the following command:

```sh
docker-compose up
```

This will start the `Host` application and a Prometheus server that will collect metrics from the application.

## Learning

This project is for learning purposes and should not be used in production as-is. However, you can use it as a basis for learning how to implement monitoring and telemetry in your own ASP.NET Core applications.
