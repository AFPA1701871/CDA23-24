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
    reset.addEventListener("click", ()=>{
        location.reload();
    })
}
// gestion du click sur demarrer
demarrer = document.querySelector("#start")
if (demarrer != undefined) {
    demarrer.addEventListener("click", demarrerJeu)
}

/**
 * Active le bouton quand les combos sont renseignées
 */
function gestionDemarrer() {
    if (lesSelect[0].value != "" && lesSelect[1].value != "") {
        document.querySelector("#start").disabled = false;
    }
}

function demarrerJeu()
{
    // bloquer l'accès aux paramètres
    lesSelect.forEach(element => {
        element.disabled=true;
    });
    demarrer.disabled=true;
}