# use the azure cli to deploy the app to an azure app service
# env variables (use azure naming convention)
$RESOURCE_GROUP = "rg-stu-offsite-ghcopilot"
$APP_SERVICE_PLAN = "asp-stu-offsite-ghcopilot"
$APP_SERVICE = "app-stu-offsite-ghcopilot"
$LOCATION = "westeurope"

# create a resource group
az group create --name $RESOURCE_GROUP --location $LOCATION

# create an app service plan
az appservice plan create --name $APP_SERVICE_PLAN --resource-group $RESOURCE_GROUP --location $LOCATION --sku FREE --is-linux

# create an app service
az webapp create --name $APP_SERVICE --resource-group $RESOURCE_GROUP --plan $APP_SERVICE_PLAN --runtime "NODE:18-lts"