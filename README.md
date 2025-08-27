# Supernova-AI


### Panoramica del Backend

Questo progetto è un'architettura a microservizi sviluppata con ASP.NET Core. Utilizza Ocelot come API Gateway per centralizzare il routing e l'autenticazione. I dati, inclusi utenti, cronologia chat e messaggi, sono persistiti in un database MongoDB. L'intera architettura segue i principi del Domain-Driven Design (DDD), con una chiara separazione delle responsabilità per ogni servizio.

### Struttura del Progetto
Il progetto è organizzato in una soluzione principale che contiene i seguenti microservizi, ognuno con un ruolo specifico:

ApiGateway: L'unico punto d'ingresso per il frontend. Gestisce il routing delle richieste ai vari servizi e applica la logica di autenticazione.

AuthService: Microservizio dedicato alla gestione degli utenti, inclusi la registrazione e l'autenticazione tramite JWT.

ChatService: Microservizio che si occupa di tutta la logica del chatbot, dall'interazione con l'API di OpenRouter alla gestione della cronologia delle conversazioni.

Ogni microservizio è a sua volta suddiviso in progetti di librerie di classi per rispettare i principi del DDD: Api, Application, Domain, e Infrastructure.

### Avvio del Progetto
Per avviare il backend e testarlo, segui questi passaggi:

Assicurati che MongoDB sia in esecuzione: Il tuo server MongoDB deve essere attivo per permettere ai servizi di connettersi.

Configura le connessioni: Aggiorna le stringhe di connessione al database e le chiavi segrete JWT nei file appsettings.json di AuthService e ChatService.

Avvia i servizi: Avvia i singoli microservizi dalla loro directory principale. Puoi usare il terminale (dotnet run) o la funzione di avvio multiplo del tuo IDE (ad esempio, tramite un file launchSettings.json).

Avvia l'API Gateway: L'ApiGateway deve essere l'ultimo servizio ad essere avviato, poiché dipende dalla disponibilità dei servizi a cui deve instradare le richieste.