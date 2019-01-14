# Smart home agent

Ce dépôt contient :

- [un export zip](https://github.com/badreddine-dlaila/DialogFlow.OH.Proxy/raw/master/Smart-Home-14012019.zip) d'un agent dialogflow dont pour piloter une maison intelligente.

- une Api .NET core (webhook) qui receoit des dialogflow webhook request sur l'adresse https://smarthome-proxy.azurewebsites.net/api/webhook/ et execute l'intent/action

    >1. Si vous souhaitez lancer l'api en local, suivez les instructions [ici](https://code.visualstudio.com/docs/other/dotnet)
    >2. Lancez [ngrok](https://ngrok.com/) en local et copier le lien sécurisé (https) dans le champ webhook du fulfillment
    dans dialogflow 

## [Home dashboard](http://176.130.227.69:8080/basicui/app)

    Un dashboard est disponible sur l'adresse : http://176.130.227.69:8080/basicui/app

![openhab dashboard](Images/B5CDAA9F-1D8F-4796-854B-252E93298229.jpg)

pour éviter les surprise, référez-vous à l'agent example inclus dans ce dépôt ([Smart-Home-14012019.zip](https://github.com/badreddine-dlaila/DialogFlow.OH.Proxy/raw/master/Smart-Home-14012019.zip))

Le [proxy](https://smarthome-proxy.azurewebsites.net/api/info) peut interpréter
1. les intents suivants ( Où * est le prefixe de votre projet. Dans l'exemple Smart-Home, * est remplacé par smarthome, pour donner par exemple *smarthome.device.switch.off* )
    - *.device.switch.off
    - *.device.switch.on
    - *.device.brightness.set
 2. les action suivantes ( Où * peut etre par example le nom de l'intent, Dans l'exemple Smart-Home, * est remplacé par smarthome, pour donner par exemple *smarthome.device.switch.off* ):
    - *.off
    - *.on
    - *.set
    
 



