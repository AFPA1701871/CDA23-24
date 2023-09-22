
/************************LES VARIABLES ******************************************** */
tabCartesRetournees = []; // contient les cartes affichés en même temps

/************************LES LISTENERS ******************************************** */
// gestion des combobox
lesSelect = document.querySelectorAll("select");
if (lesSelect != undefined) {
    lesSelect.forEach(element => {
        element.addEventListener("change", gestionDemarrer)
    });
}
// gestion du click sur reset
reset = document.querySelector("#reset")
if (reset != undefined) {
    reset.addEventListener("click", () => {
        location.reload();
    })
}
// gestion du click sur demarrer
demarrer = document.querySelector("#start")
if (demarrer != undefined) {
    demarrer.addEventListener("click", demarrerJeu)
}

/************************LES FONCTIONS ******************************************** */
/**
 * Active le bouton quand les combos sont renseignées
 */
function gestionDemarrer() {
    if (lesSelect[0].value != "" && lesSelect[1].value != "") {
        document.querySelector("#start").disabled = false;
    }
}

/**
 * Gère les paramètres, ffiches les cartes et lance le jeu
 */
function demarrerJeu() {
    // bloquer l'accès aux paramètres
    lesSelect.forEach(element => {
        element.disabled = true;
    });
    demarrer.disabled = true;

    nbPair = lesSelect[1].value
    // Preparer la repartition aléatoire des cartes
    tabCartes = gererRepartitionCartes(nbPair)

    //afficher les cartes
    cards = document.querySelector(".cards")
    temp = document.querySelector("template")
    for (let index = 0; index < nbPair * 2; index++) {
        elt = temp.content.cloneNode(true)
        cards.appendChild(elt);
        eltAjoute = cards.children[index]
        eltAjoute.addEventListener("click", clickCarte)
        eltAjoute.setAttribute("data-image", tabCartes[index])
    }
}
/**
 * Met un numero pour chaque pair 2 fois dans le tableau et le trie aléatoirement
 * @param {*} nbPair 
 */
function gererRepartitionCartes(nbPair) {
    tab = []
    for (let index = 0; index < nbPair; index++) {
        tab.push(index + 1)
        tab.push(index + 1)// on veut 2 fois chaque valeur dans le tableau pour constituer des pairs
    }
    tab.sort(() => Math.random() - 0.5)
    console.log(tab)
    return tab
}


function clickCarte(event) {
    let card = event.target
    if (tabCartesRetournees.length < 2) {
        FlipCard(card, true);
        if (!tabCartesRetournees.includes(card)) // pour eviter le clic 2 fois sur la même carte
            tabCartesRetournees.push(card);
        if (tabCartesRetournees.length == 2) { // au 2ème clic on entre avec longueur =1, on retourne une carte donc longueur =2
            if (CheckCard(tabCartesRetournees)) {
                // les cartes sont les m^mes
                //on retire les listeners de ces cartes
                tabCartesRetournees.forEach(element => {
                    element.removeEventListener("click", clickCarte)
                });

                //on vide le tableau des cartes cliquées
                tabCartesRetournees = []
            }
            else {
                // les cartes ne sont pas les mêmes 
                setTimeout(() => {
                    tabCartesRetournees.forEach(element => {
                        FlipCard(element, false)
                    })

                    //on vide le tableau des cartes cliquées
                    tabCartesRetournees = []
                }, 3000)
            }
        }
    }
}


/**
 * Retourne la carte
 * si verso est vrai, on affiche l'image, sinon on remets la plage
 * @param {*} card balise image concernée
 * @param {*} verso  boolean
 */
function FlipCard(card, verso) {
    card.src = verso ? "./Images/" + card.getAttribute("data-image") + ".jpg" : "./Images/plage.jpg"
}

/**
 * Vérifie si les cartes sont identiques
 * @param {*} tab 
 * @returns vrai si les cartes sont identiques faux sinon
 */
function CheckCard(tab) {
    let dataimage = tab[0].getAttribute("data-image")
    let index = 1
    while (index < tab.length && tab[index].getAttribute("data-image") == dataimage) {
        index++
    }
    if (index == tab.length) return true
    return false
}
