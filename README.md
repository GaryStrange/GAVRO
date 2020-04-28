# GAVRO
This repo demonstrates how you can manage schema evolution in a big-data platform using Microsoft Azure technologies.

## Introduction
The very short story; follow the guidance below to build-out a data ingestion method that incorporates schema evolution management. An Azure Function mocks an online order processing service. Orders are published to an Event Hub and captured in AVRO files using the ![Event Hub Data Capture feature](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-overview). The AVRO files are stored in a Storage Account which is then processed by Azure Databricks. The method enables the accurate deserialisation of data that's evoling overtime.

For the full write up head on over to the Medium story [placeholder-link].

If you want to dive right in do the following...

## Provisioning

![Architecture](https://github.com/GaryStrange/GAVRO/blob/master/GAVRO.png)

To build out the Azure infrastructure

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FGaryStrange%2Fazure-quickstart-templates%2Fmaster%2FGAVRO%2Fazuredeploy.json" target="_blank">
    <img src="https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.png"/>
</a>

Create a new resource group or create a new one. Below is a screenshot of the resources it will create.

![Resource Group](https://github.com/GaryStrange/GAVRO/blob/master/GavroResourceGroup.PNG)

## Azure Functions

Next, clone the ![Publish Function App solution](https://github.com/GaryStrange/GAVRO/tree/master/PublishFunctionApp). You'll need to then publish and target the provision Function App 'gavrofunapp'. I'm using visual studio in the screenshot below.

need screenshot!

## Databricks

Almost there; Databricks needs a bit of manual work to setup a storage SAS token, cluster and import the notebook.

### SAS Token
### Cluster Config
### Notebook Import

