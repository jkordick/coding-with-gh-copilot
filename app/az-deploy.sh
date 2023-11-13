# create some env variables
RESOURCE_GROUP_NAME=rg-demo-app
LOCATION=westeurope
APP_NAME=app-demo-app-1

# create more env variables
RESOURCE_GROUP_NAME_1=rg-demo-app-2
LOCATION_1=westeurope
APP_NAME_1=app-demo-app-2

# create a resource group
az group create --name $RESOURCE_GROUP_NAME --location $LOCATION

# create an app service plan
az appservice plan create --name $APP_NAME --resource-group $RESOURCE_GROUP_NAME --sku F1 --is-linux

# create a web app
az webapp create --name $APP_NAME --resource-group $RESOURCE_GROUP_NAME --plan $APP_NAME 

# deploy the app
az webapp up --name $APP_NAME --resource-group $RESOURCE_GROUP_NAME

## create another resource group
az group create --name $RESOURCE_GROUP_NAME_1 --location $LOCATION_1

