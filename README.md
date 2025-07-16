# OverpassAPI

Progetto realizzato per l'esame di Applicazioni Web- Modulo Cloud aa 2024-2025

Lo scopo del progetto è un'applicazione web in grado di ottenere i Punti di Interesse e le Strade della provincia di Ancona da OpenStreetMap tramite Overpass API.
Overpass API è uno strumento che viene impiegato per interrogare i dati da OpenStreetMap, dove è possibile eseguire richieste tramite query che contengano nodi, strade, relazioni.

Documentazione Overpass API: https://overpass-api.de/

Overpass Turbo è un tool per eseguire le richieste tramite query per ottenere dati in formato JSON e visualizzarli su una mappa. Utile per eseguire test delle query: https://overpass-turbo.eu/

I dati verranno mostrati in una pagina HTML.

Le query utilizzate sono le seguenti:

Nodi: overpass-api.de/api/interpreter?data=[out:json][timeout:25];area["name"="Ancona"]["admin_level"="6"]->.a;(node["amenity"](area.a);node["tourism"](area.a);node["leisure"](area.a););out;

Strade: overpass-api.de/api/interpreter?data=[out:json][timeout:25];area["name"="Ancona"]["admin_level"="6"]->.a;(way(area.a););out body 200;>;out skel qt 10;

NOTA: i numeri presenti nella query delle strade su out body 200 e out skel 10, sono stati necessari poiché OverpassAPI è un po' lento e non riesce a gestire una mole enorme di dati. out body 200 implica che si otterranno le prime 200 strade che Overpass trova, invece out skel qt 10 fa riferimento a 10 nodi associati alle strade.

Obiettivi:
    1. Creare una pagina che mostra una tabella dei Punti di Interesse della Provincia di Ancona; (NodiOverpass/ElencoNodi)
    2. Creare un filtro nella pagina dell'Elenco dei Punti di Interesse per ottenerne di un determinato tipo; (NodiOverpass/FiltroNodi?filter=...)
    3. Creare una pagina per mostrare Strade della Provincia di Ancona; (StradeOverpass/ElencoStrade)

I principali tag utilizzati per l'ottenimento dei Nodi sono: amenity, leisure e tourism. 
Di seguito sono presenti i tag e i sottotag utilizzati su Overpass e benché ne siano stati usati 3, è possibile aggiungerli in un secondo momento:
    
    • highway=* - Infrastrutture stradali:
        ◦ motorway, primary, residential, footway, cycleway
        ◦ Sottotag: sidewalk=, cycleway=, maxspeed=, lanes=,
    
    • building=* — Tipi di edifici
        ◦ house, school, church, commercial, garage
        ◦ Sottotag: building:levels=, roof:shape=, entrance=
    
    • landuse=* — Uso del suolo
        ◦ residential, commercial, forest, farmland, grass
    
    • natural=* — Elementi naturali
        ◦ tree, water, peak, beach, cliff
        ◦ Sottotag: natural=tree con species=*, height=*
    
    • shop=* — Attività commerciali
        ◦ supermarket, bakery, clothes, electronics, florist
    
    • amenity=* — Servizi pubblici e privati
        ◦ school, hospital, restaurant, parking
        ◦ Sottotag: cuisine=*, diet=*, capacity=*, opening_hours=*
    
    • railway=* — Infrastrutture ferroviarie
        ◦ station, halt, level_crossing, rail, subway_entrance
    
    • public_transport=* — Trasporto pubblico
        ◦ stop_position, platform, station
        ◦ Sottotag: bus=yes, train=yes, route_ref=*
    
    • place=* — Località geografiche
        ◦ city, town, village, hamlet, suburb
    
    • leisure=* — Tempo libero
        ◦ park, pitch, playground, sports_centre, swimming_pool


Tecnologie utilizzate:
    • Overpass API;
    • .NET Core 8.0;
    • ASP.NET MVC;
    • Architettura REST;
    • Docker;
