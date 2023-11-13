# welcome to coding with github copilot ✨

## what is this repository?
this repository was initially created for a microsoft stu internal event to show our colleagues how easy it is to code with gh copilot, how it feels to develop with an autocomplete on steriods and teach them how to inspire customers to use gh copilot.

## pre-requisites
1. create a [github account](https://github.com/signup)  
2. get access to github copilot
    1. microsofties can request access to gh copilot [here](https://repos.opensource.microsoft.com/orgs/MicrosoftCopilot)
    2. everyone else can buy a licence [here](https://copilot.github.com/) (it's free for students + teachers!)
3. setup
    1. gh codespace
        1. in this github repository click on code & create codespace on main ![create codespaces on main](./images/on-main.png)
        2. install github copilot extensions
            1. open extensions tab
            2. search for github copilot and github copilot chat
            3. install
            4. reload the page
        3. open terminal
            1. `cd app`
            2. `npm install`
            3. `npm start` 
            4. click open in browser ![open in browser](./images/open-in-browser.png)
            5. be happy :)
    2. local 
        1. install the needed extensions for your ide
            1. [vscode](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot)
            2. [visual studio](https://marketplace.visualstudio.com/items?itemName=GitHub.copilotvs)
            3. [jetbrains ides](https://plugins.jetbrains.com/plugin/17718-github-copilot)
        2. install everything needed on your local pc (but not today - we use gh codespaces!)

## tasks

### warm-up: playing around with html, css and javascript
1. change the background color to a css gradient of your choice
2. add a button to the page
3. add a div that displays a number
4. add an on-click event to the button that increases the number by 1

> tip: if you do not know how to do something, just ask github copilot chat for help :) 

### main tasks: deployment
1. open the az-deploy.sh and create an azure deployment for your app with azure cli
    1. use environment variables for the resource group name, app service plan name, app service name and location
    1. create azure app service
    2. create a linux app service plan
    3. use node 18
    4. deploy your app

### bonus tasks: testing, tbd...
1. 1. ask github copilot to write you a few tests for your on-click event 
