DE FACUT:

1. adaugare metoda in DataManager -->> SetData -->> are rolul de a da update la listele create din DataManager, dupa fiecare setare facuta la finalul acestora -- EDE

3. adaugare interval orar AddMinutes(Double)

4. configurare Utilizator 

5. configurare Admin 

6. implementarea programului / main

Dupa fiecare finalizare de task, acesta se va sterge.

2. Cinema:
Dezvoltati o aplicatie pentru gestionarea filmelor si rezervarilor unui cinematograf.

(~2p)
Utilizatorul va putea efectua urmatoarele operatii:
- sa vizualizeze lista tuturor filmelor care inca mai ruleaza
- sa caute filmele care ruleaza intr-o anumita zi si, optional, intr-un anumit interval orar
- sa inspecteze un un film pentru a vedea descrierea, programul de rulare (zi si interval orar) si alte detalii ale filmului
- sa caute un film dupa nume
- sa rezerve intre 1 si 5 locuri la o rulare specifica a unui film
- sesiunea unui utilizator nu se va salva la inchiderea programului

(~2p)
Administratorul va putea efectua urmatoarele operatii:
- sa introduca filme noi (impreuna cu zilele si intervalele orare in care ruleaza)
- sa adauge/scoata intervale orare sau zile in care ruleaza filmul
- sa scoata complet un film de la rulare
- sa modifice numarul maxim de locuri pentru o rulare (sa schimbe sala)
- sa vizualizeze numarul de locuri ocupate pentru fiecare rulare

(~2p)
La introducerea unor rulari ale filmelor trebuie sa se verifice daca sala in care se va realiza proiectia are intervalul orar disponibil. Salile pot fi hardcoded (sa ramana intotdeauna aceleasi). Doar intervalele orare alocate filmelor se vor schimba.

(~1p)
Creati un meniu in consola pentru a putea folosi toate aceste optiuni. Programul trebuie sa poata trece de la utilizator la administrator fara a fi repornit. (Optional: puteti realiza o interfata grafica in ce tehnologie doriti (WPF, MAUI, Windows Forms etc.), cu conditia ca limbajul de programare folosit sa fie C#).

(~2p)
La inchiderea programului, starea programului (exceptand partea de utilizator) trebuie salvata intr-un fisier (text, csv, alte formate) sau mai multe, iar la pornirea programului, acesta va cauta fisierul si va incarca toate datele din el. In cazul in care fisierul nu exista, programul va porni fara a incarca nimic, dar la inchidere va salva noile date intr-un fisier nou. Pentru acest scop se va implementa un serviciu separat care primeste toate datele de salvat/incarcat si salveaza/incarca. Functionalitatea de salvare si incarcare nu se va implementa in interiorul claselor ce ofera functionalitatea principala a programului.

Functionalitatea trebuie separata de interfata. Clasele aferente functionalitatilor de mai sus trebuie sa nu contina cod ce tine de interfata (scris/citit din consola etc.). Programul trebuie sa nu se poata termina necontrolat (cu exceptii). Toate exceptiile posibile trebuie prinse si tratate.

Oficiu: 1p
