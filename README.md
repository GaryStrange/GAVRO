# GAVRO

## Introduction

This repo demonstrates how you can manage schema evolution in a big-data platform using Microsoft Azure technologies.

The very short story, follow the guidance below to build-out a data ingestion method that incorporates schema evolution management. An Azure Function mocks an online order processing service. Orders are published to an Event Hub and Capture in AVRO files using the ![Event Hub Data Capture feature](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-overview). The AVRO files are storage in a Storage Account which is then processed by Azure Databricks. The method enables the accurate deserialisation of a schema that's evoling overtime.

For the full write up head on over to the Medium story [placeholder-link].

If you want to dive right in do the following...

## Provisioning

![Architecture](https://github.com/GaryStrange/GAVRO/blob/master/GAVRO.png)

To build out the Azure infrastructure
