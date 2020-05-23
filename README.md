# GAVRO
This repo demonstrates how you can manage schema evolution in a big-data platform using Microsoft Azure technologies.

## Introduction
The very short story; follow the guidance below to build-out a data ingestion method that incorporates schema evolution management. An Azure Function mocks an online order processing service. Orders are published to an Event Hub and captured in AVRO files using the ![Event Hub Data Capture feature](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-overview). The AVRO files are stored in a Storage Account which is then processed by Azure Databricks. The method enables the accurate deserialisation of data that's evolving over time.

For the full write up head on over to the [Medium story](https://towardsdatascience.com/gavro-managed-big-data-schema-evolution-8217431f278f).

If you want to dive right in do the following...

## Provisioning

![Architecture](/GAVRO.png)

To build out the Azure infrastructure

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FGaryStrange%2Fazure-quickstart-templates%2Fmaster%2FGAVRO%2Fazuredeploy.json" target="_blank">
    <img src="https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.png"/>
</a>

As part of the ARM template deploy you'll need to either create a new resource group or use an existing one. Below is a screenshot of the resources it will create.

![Resource Group](https://github.com/GaryStrange/GAVRO/blob/master/GavroResourceGroup.PNG)

## Azure Functions

Next, clone and open the ![Publish Function App solution](https://github.com/GaryStrange/GAVRO/tree/master/PublishFunctionApp). You'll need to then publish and target the provisioned Function App 'gavrofunapp'. I'm using visual studio in the screenshot below.

![Function Publish](https://github.com/GaryStrange/GAVRO/blob/master/GavroPublish.PNG)

## Databricks

Almost there; Databricks needs a bit of manual work to setup a storage SAS token, cluster and import the notebook.

### SAS Token

Create a SAS token for the provisioned gavrostorage account. You'll need this to allow the Databricks notebook access to the AVRO data. The screenshot below shows the option I used for my token.

![SAS Token](https://github.com/GaryStrange/GAVRO/blob/master/CreateSAS.PNG)

### Cluster Config

From within Databricks ![create a new cluster](https://docs.databricks.com/clusters/create.html), below is an image of the config I used with the items that need editing from the default highlighted. When you hit 'Create Cluster' a new single-node cluster will be created with the name 'GAVRO'.

![Cluster Config](https://github.com/GaryStrange/GAVRO/blob/master/GavroClusterConfig.PNG)

### Notebook Import

Again from Databricks ![import the notebook](https://docs.databricks.com/notebooks/notebooks-manage.html) linked below. Before you can run the notebook you'll need to paste your SAS token into cell 2.

![Notebook](https://github.com/GaryStrange/GAVRO/blob/master/Notebooks/py-ReadGAVRO.html)

#### Cell 2
```
storageAccName = "gavrostorage"
containerName = "gavrocontainer"
storageSAS = "?sv=2019-10-10&ss=b&srt=sco&sp=rl&se=2020-04-30T17:50:43Z&st=2020-04-29T09:50:43Z&spr=https&sig=kqb6z5IXagf4nZJNBsaHMs4TL5FWsnwYLTkF3w3TQiM%3D"
```

# Finally

Sorry, there's a few steps to put this all together. I need to work on making it simpler and invest some time in automation. However, if you managed to follow, you should now have a notebook that can analyse the SalesOrder data as it has evolved. In the later cells of the Notebook, I also include examples of using implicit schema by allowing Spark to decide. You may also decide to read all the v1.x sets together as they're non-breaking and the v1.1 schema is backwardly compatible with v1.0.
